using Substrate;
using Substrate.Core;
using Substrate.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CreativeModePlus
{
    public unsafe class Tool
    {
        private struct Fill
        {
            public Fill(int inX, int inY, int inDir)
            {
                x = inX;
                y = inY;
                dir = inDir;

            }

            public int x, y, dir;

        }

        public static int disp, disp2;

        private int[][] clr = null,
                        selC = null,
                        resC = null,
                        lyr = null;
        private int plcCol, scl;
        private Block[][] map = null,
                          selB = null,
                          resB = null;
        private Block plc;
        private Bitmap img = null;
        private BitmapData imgChg = null;
        private PictureBox display;
        private Point[][] toolArea = null;
        private Point origin;
        private Rectangle selectArea,
                          srcBox;
        private Size toolSize;

        public int Scale { get { return scl; } set { scl = value; } }
        public int[][] Clr { get { return clr; } }
        public int[][] Lyr { get { return lyr; } }
        public Block[][] Map { get { return map; } }
        public Bitmap Img { get { return img; } }
        public Point[][] affected { get { return toolArea; } }
        public Point Origin { get { return origin; } set { origin = value; } }
        public Rectangle Area { get { return selectArea; } set { selectArea = value; } }
        public Size size { get { return toolSize; } }

        public void dumMove(Point herp, Point derp, MouseButtons hd) { }
        public void dumDown(Point herp) { }
        public void dumUp(Point herp) { }
        public void dumClick(Point herp) { }

        public Tool(PictureBox dis)
        {
            toolSize = new Size();
            selectArea = new Rectangle(-1, -1, 0, 0);
            origin = new Point(-1, -1);
            display = dis;
            scl = 1;

            disp = 1090453652;
            disp2 = -1795227500;

        }

        public void finishLimits(Limits l)
        {
            clr = l.clr;
            lyr = l.lyr;
            map = l.map;

        }

        public void updateImage()
        {
            LoadSave.startThread(RunThread.Update);

        }

        private void refreshImage()
        {
            Point pt = Point.Empty;

            for (pt.X = 0; pt.X < LoadSave.W; pt.X++)
                for (pt.Y = 0; pt.Y < LoadSave.H; pt.Y++)
                    setPixel(pt, mixColor(clr[pt.X][pt.Y], lyr[pt.X][pt.Y]));

            display.Size = img.Size;
            display.Image = img;

        }

        public void showImage(Bitmap inMap)
        {
            if (img != null && img != inMap)
                img.Dispose();

            if (img != inMap)
                img = inMap;

            srcBox = new Rectangle(Point.Empty, inMap.Size);

            scaleImage(0);

        }

        public void scaleImage(int delta)
        {
            Point pt = Point.Empty;

            if (img != null)
            {
                img.Dispose();

                if (delta < 0 && scl > 1)
                    scl -= 1;

                else if (delta > 0 && scl < 8)
                    scl += 1;

                img = new Bitmap(LoadSave.W * scl, LoadSave.H * scl);

                refreshImage();

            }
        }

        private void removeSelection()
        {
            Point pt = Point.Empty;

            for (pt.X = 0; pt.X < LoadSave.W; pt.X++)
            {
                for (pt.Y = 0; pt.Y < LoadSave.H; pt.Y++)
                {
                    lyr[pt.Y][pt.Y] = 0;
                    setPixel(pt, clr[pt.X][pt.Y]);

                }
            }
        }

        public void undo()
        {
            ElemUndo undo = Undo.undo();

            if (undo != null)
            {
                selectArea = undo.undo(selectArea, clr, lyr, map);
                refreshImage();

            }
        }

        public void redo()
        {
            ElemUndo redo = Undo.redo();

            if (redo != null)
            {
                selectArea = redo.undo(selectArea, clr, lyr, map);
                refreshImage();

            }
        }

        public void getBlockInfo(ToolStripStatusLabel block, Point pt)
        {
            Point aPt = adj(pt, false);

            if (map != null &&
                aPt.X > -1 && aPt.X < LoadSave.W &&
                aPt.Y > -1 && aPt.Y < LoadSave.H)
            {
                if (clr[aPt.X][aPt.Y] != -65281)
                    block.Text = "" + ((BlockNames)map[aPt.X][aPt.Y].ID);

                else
                    block.Text = "Unavailable";

            }
        }

        public void setBlockType(int ID, Form main)
        {
            AddData.getData(ID, main);

            plc.ID = AddData.Data.ID;
            plc.Data = AddData.Data.Data;
            plc.ent = AddData.Data.ent;

            plcCol = BlockColor.getBlockColor(ID);

        }

        public DoMove getMove(String cmd)
        {
            DoMove toRet = dumMove;

            switch (cmd)
            {
                case "Select":
                    toRet = selection;

                    break;

                case "Paint":
                    toRet = moveCursor;

                    break;

                case "Pencil":
                    toRet = movePencil;

                    break;

                case "Move":
                    toRet = moveSelect;

                    break;

                case "Fill":
                    toRet = dumMove;

                    break;

            }

            return toRet;

        }

        public DoDown getDown(String cmd)
        {
            DoDown toRet = dumDown;

            switch (cmd)
            {
                case "Select":
                    toRet = setOrigin;

                    break;

                case "Move":
                    toRet = downSelect;

                    break;

                case "Paint":
                    toRet = dumDown;

                    break;

                case "Pencil":
                    toRet = dumDown;

                    break;

                case "Fill":
                    toRet = dumDown;

                    break;

            }

            return toRet;

        }

        public DoUp getUp(String cmd)
        {
            DoUp toRet = dumUp;

            switch (cmd)
            {
                case "Select":
                    toRet = setRect;

                    break;

                case "Move":
                    toRet = upSelect;

                    break;

                case "Paint":
                    toRet = dumUp;

                    break;

                case "Pencil":
                    toRet = dumUp;

                    break;

                case "Fill":
                    toRet = dumUp;

                    break;

            }

            return toRet;

        }

        public DoClick getClick(String cmd)
        {
            DoClick toRet = dumClick;

            switch (cmd)
            {
                case "Select":
                    toRet = dumClick;

                    break;

                case "Paint":
                    toRet = paint;

                    break;

                case "Pencil":
                    toRet = paint;

                    break;

                case "Fill":
                    toRet = fill;

                    break;

                case "Move":
                    toRet = dumClick;

                    break;

            }

            return toRet;

        }

        private void setPixel(Point pt, int plcClr)
        {
            int i, j, imgWid;

            imgChg = img.LockBits(srcBox, ImageLockMode.ReadWrite, img.PixelFormat);
            int* chg = ((int*)imgChg.Scan0);
            imgWid = imgChg.Stride / 4;

            for (j = pt.Y * scl; j < scl + pt.Y * scl; j++)
            {
                for (i = pt.X * scl; i < scl + pt.X * scl; i++)
                {
                    if (scl == 1 ||
                      ((i % scl != 0 || j % 2 != 0) &&
                      (j % scl != 0 || i % 2 != 0)))
                        chg[j * imgWid + i] = plcClr;

                    else if ((i % scl == 0 && j % 2 == 0) || (j % scl == 0 && i % 2 == 0))
                        chg[j * imgWid + i] = mixColor(plcClr, 1056964608);//0x3f000000

                }
            }

            img.UnlockBits(imgChg);

        }

        public int mixColor(int one, int two)
        {
            int toRet = 0;
            byte r1 = *(((byte*)&one) + 2),
                 g1 = *(((byte*)&one) + 1),
                 b1 = *((byte*)&one),
                 r2 = *(((byte*)&two) + 2),
                 g2 = *(((byte*)&two) + 1),
                 b2 = *((byte*)&two);
            byte* ar = ((byte*)&toRet) + 3,
                  rr = ((byte*)&toRet) + 2,
                  gr = ((byte*)&toRet) + 1,
                  br = ((byte*)&toRet);
            double a;

            a = *(((byte*)&two) + 3);
            *ar = ((byte)255);
            *rr = (byte)(r1 * (255 - a) / 255 + r2 * a / 255);
            *gr = (byte)(g1 * (255 - a) / 255 + g2 * a / 255);
            *br = (byte)(b1 * (255 - a) / 255 + b2 * a / 255);

            return toRet;

        }

        private void selection(Point pt, Point prev, MouseButtons mb)
        {
            if (origin.X != -1 && mb == MouseButtons.Left)
            {
                Point delta = new Point(pt.X - prev.X, pt.Y - prev.Y),
                      quad = new Point(prev.X - origin.X, prev.Y - origin.Y),
                      bound = new Point(pt.X - origin.X, pt.Y - origin.Y);

                if (quad.X * delta.X < 0) // gesture directions disagree
                    retract(prev.X,
                             pt.X,
                             getDelta(delta.X),
                             origin.Y,
                             prev.Y,
                             getDelta(quad.Y));

                else // gesture directions agree
                    expand(prev.X,
                            pt.X,
                            getDelta(delta.X),
                            origin.Y,
                            pt.Y,
                            getDelta(bound.Y));

                if (quad.Y * delta.Y < 0) // gesture directions disagree
                    retract(origin.X,
                             prev.X,
                             getDelta(quad.X),
                             prev.Y,
                             pt.Y,
                             getDelta(delta.Y));

                else // gesture directions agree
                    expand(origin.X,
                            pt.X,
                            getDelta(bound.X),
                            prev.Y,
                            pt.Y,
                            getDelta(delta.Y));

                display.Image = img;

            }
        }

        private void expand(int outlim1,
                             int outlim2,
                             int outD,
                             int inlim1,
                             int inlim2,
                             int inD)
        {
            Point pt = Point.Empty;

            outlim2 += outD;
            inlim2 += inD;

            for (pt.X = outlim1; pt.X != outlim2; pt.X += outD)
                for (pt.Y = inlim1; pt.Y != inlim2; pt.Y += inD)
                    setPixel(pt, mixColor(clr[pt.X][pt.Y], disp));

        }

        private void retract(int outlim1,
                              int outlim2,
                              int outD,
                              int inlim1,
                              int inlim2,
                              int inD)
        {
            Point pt = Point.Empty;

            outlim2 += outD;
            inlim2 += inD;

            for (pt.X = outlim1; pt.X != outlim2; pt.X += outD)
                for (pt.Y = inlim1; pt.Y != inlim2; pt.Y += inD)
                    setPixel(pt, clr[pt.X][pt.Y]);

        }

        private int getDelta(int i)
        {
            return (i < 0) ? -1 : 1;

        }

        public Point adj(Point loc, bool comp)
        {
            Point toRet = new Point(loc.X / scl, loc.Y / scl);

            if (comp)
            {
                if (toRet.X > 511)
                    toRet.X = 511;

                else if (toRet.X < 0)
                    toRet.X = 0;

                if (toRet.Y > 511)
                    toRet.Y = 511;

                else if (toRet.Y < 0)
                    toRet.Y = 0;

            }

            return toRet;

        }

        public void setRect(Point lr)
        {
            int w, h;
            Point pt;

            pt = new Point((lr.X < selectArea.X) ? lr.X : selectArea.X,
                           (lr.Y < selectArea.Y) ? lr.Y : selectArea.Y);

            selectArea.Width = Math.Abs(lr.X - selectArea.X) + 1;
            selectArea.Height = Math.Abs(lr.Y - selectArea.Y) + 1;
            selectArea.X = pt.X;
            selectArea.Y = pt.Y;
            w = selectArea.Right;
            h = selectArea.Bottom;

            createSelectMover();

            for (pt.X = selectArea.X; pt.X < w; pt.X++)
            {
                for (pt.Y = selectArea.Y; pt.Y < h; pt.Y++)
                {
                    setPixel(pt, mixColor(clr[pt.X][pt.Y], disp));
                    lyr[pt.X][pt.Y] = disp;

                }
            }

            display.Image = img;

        }

        public void setOrigin(Point or)
        {
            if (Undo.peek() != "Select")
                Undo.add(new ElemUndo(selectArea, clr, lyr, map, "Select"));

            if (selectArea.Width != 0)
                killSelect();

            origin.X = or.X;
            origin.Y = or.Y;
            selectArea.X = or.X;
            selectArea.Y = or.Y;

        }

        public void killSelect()
        {
            Point pt = Point.Empty;

            if (selectArea.Width != 0)
            {
                for (pt.X = selectArea.X; pt.X < selectArea.Right; pt.X++)
                {
                    for (pt.Y = selectArea.Y; pt.Y < selectArea.Bottom; pt.Y++)
                    {
                        setPixel(pt, clr[pt.X][pt.Y]);
                        lyr[pt.X][pt.Y] = 0;

                    }
                }

                selectArea.Width = selectArea.Height = 0;
                selectArea.X = selectArea.Y = origin.X = origin.Y = -1;

                display.Image = img;

            }
        }

        public void resize(Bitmap cur)
        {
            int i, j;

            if (toolSize.Width != cur.Width)
            {
                Rectangle srcCur = new Rectangle(Point.Empty, cur.Size);
                BitmapData curRd =
                 cur.LockBits(srcCur,
                               ImageLockMode.ReadOnly,
                               PixelFormat.Format32bppArgb);
                int* rd = ((int*)curRd.Scan0);
                int bf = curRd.Stride / 4;

                toolSize = cur.Size;
                toolArea = new Point[toolSize.Height][];

                for (i = 0; i < toolSize.Height; i++)
                {
                    toolArea[i] = new Point[toolSize.Width];

                    for (j = 0; j < toolSize.Width; j++)
                    {
                        if (rd[i * bf + j] == -16777216) // check for 0xff000000
                            toolArea[i][j] = new Point(j - cur.Width / 2, i - cur.Height / 2);

                        else
                            toolArea[i][j] = Point.Empty;

                    }
                }

                cur.UnlockBits(curRd);

            }
        }

        private void moveCursor(Point pt, Point prev, MouseButtons mb)
        {
            if ((pt.X != prev.X || pt.Y != prev.Y) && img != null)
            {
                placeCursor(prev, disp, 0, false);

                placeCursor(pt, disp2, disp, true);

            }

            if (mb == MouseButtons.Left)
                paint(pt);

        }

        public void placeCursor(Point pt, int col1, int col2, bool show)
        {
            int i, j;
            Point loc = Point.Empty;

            for (i = 0; i < toolSize.Height; i++)
            {
                for (j = 0; j < toolSize.Width; j++)
                {
                    loc.X = pt.X + toolArea[i][j].X;
                    loc.Y = pt.Y + toolArea[i][j].Y;

                    if (loc.X > -1 && loc.X < LoadSave.W && loc.Y > -1 && loc.Y < LoadSave.H)
                    {
                        if (lyr[loc.X][loc.Y] == disp)
                            setPixel(loc, mixColor(clr[loc.X][loc.Y], col1));

                        else
                            setPixel(loc, mixColor(clr[loc.X][loc.Y], col2));

                    }
                }
            }

            if (show)
                display.Image = img;

        }

        private void movePencil(Point pt, Point prev, MouseButtons e)
        {
            if (e == MouseButtons.Left)
                paint(pt);

        }

        private void paint(Point pt)
        {
            int i, j;
            Point loc = Point.Empty;

            if (img != null)
            {
                if (Undo.peek() != "Paint")
                    Undo.add(new ElemUndo(selectArea, clr, lyr, map, "Paint"));

                for (i = 0; i < toolSize.Width; i++)
                {
                    for (j = 0; j < toolSize.Height; j++)
                    {
                        loc.X = toolArea[i][j].X + pt.X;
                        loc.Y = toolArea[i][j].Y + pt.Y;

                        if ((loc.X > -1 && loc.X < LoadSave.W &&
                             loc.Y > -1 && loc.Y < LoadSave.H) &&
                           (selectArea.Width == 0 || lyr[loc.X][loc.Y] == disp))
                        {
                            clr[loc.X][loc.Y] = plcCol;

                            if (Tools.Active == "Paint")
                                setPixel(loc, mixColor(plcCol, disp));

                            else
                                setPixel(loc, mixColor(plcCol, lyr[loc.X][loc.Y]));

                            if (clr[loc.X][loc.Y] != -65281)
                            {
                                map[loc.X][loc.Y].ID = plc.ID;
                                map[loc.X][loc.Y].Data = plc.Data;
                                map[loc.X][loc.Y].ent = plc.ent;

                            }
                        }
                    }
                }

                display.Image = img;

            }
        }

        private void fill(Point pt)
        {
            int rep = -1;

            if (img != null)
            {
                if (Undo.peek() != "Fill")
                    Undo.add(new ElemUndo(selectArea, clr, lyr, map, "Fill"));

                if (clr[pt.X][pt.Y] != -65281)
                    rep = map[pt.X][pt.Y].ID;

                if (rep != -1 && Control.ModifierKeys == Keys.Shift)
                    fillComplete(pt, rep);

                else if (rep != -1)
                    fillPart(pt.X, pt.Y, rep);

                completeFill();

                display.Image = img;

            }
        }

        private void fillPart(int x, int y, int rep)
        {
            Fill st = new Fill(x, y, 0);
            Queue<Fill> que = new Queue<Fill>();
            que.Enqueue(st);

            while (que.Count != 0)
            {
                st = que.Dequeue();

                if (st.x > -1 && st.x < LoadSave.W && st.y > -1 && st.y < LoadSave.H &&
                    map[st.x][st.y].ID == rep && lyr[st.x][st.y] != -16711936 &&
                  (selectArea.Width == 0 || lyr[st.x][st.y] == disp))
                {
                    lyr[st.x][st.y] = -16711936; // set to 0xff00ff00

                    if (st.dir != 3)
                        que.Enqueue(new Fill(st.x, st.y - 1, 1));

                    if (st.dir != 4)
                        que.Enqueue(new Fill(st.x - 1, st.y, 2));

                    if (st.dir != 1)
                        que.Enqueue(new Fill(st.x, st.y + 1, 3));

                    if (st.dir != 2)
                        que.Enqueue(new Fill(st.x + 1, st.y, 4));

                }
            }
        }

        private void fillComplete(Point pt, int rep)
        {
            Point pc = Point.Empty, st = new Point(LoadSave.W, LoadSave.H);
            int i, j;

            if (selectArea.Width == 0 || lyr[pt.X][pt.Y] == disp)
            {
                if (lyr[pt.X][pt.Y] == disp)
                {
                    pc.X = selectArea.Location.X;
                    pc.Y = selectArea.Location.Y;
                    st.X = selectArea.Right;
                    st.Y = selectArea.Bottom;

                }

                for (i = pc.X; i < st.X; i++)
                    for (j = pc.Y; j < st.Y; j++)
                        if (clr[i][j] != -65281 && map[i][j].ID == rep)
                            lyr[i][j] = -16711936; // set to 0xff00ff00

            }
        }

        private void completeFill()
        {
            Point pt = Point.Empty;

            for (pt.X = 0; pt.X < LoadSave.W; pt.X++)
            {
                for (pt.Y = 0; pt.Y < LoadSave.H; pt.Y++)
                {
                    if (lyr[pt.X][pt.Y] == -16711936) //check for 0xff00ff00
                    {
                        if (selectArea.Width == 0)
                            lyr[pt.X][pt.Y] = 0;

                        else
                            lyr[pt.X][pt.Y] = disp;

                        clr[pt.X][pt.Y] = plcCol;
                        map[pt.X][pt.Y].ID = plc.ID;
                        map[pt.X][pt.Y].Data = plc.Data;
                        map[pt.X][pt.Y].ent = plc.ent;

                        setPixel(pt, mixColor(plcCol, lyr[pt.X][pt.Y]));

                    }
                }
            }
        }

        private void createSelectMover()
        {
            int i, j;

            selB = new Block[selectArea.Width][];
            selC = new int[selectArea.Width][];

            GC.Collect();

            for (i = 0; i < selectArea.Width; i++)
            {
                selB[i] = new Block[selectArea.Height];
                selC[i] = new int[selectArea.Height];

                for (j = 0; j < selectArea.Height; j++)
                {
                    selC[i][j] = -65281;
                    selB[i][j] = new Block();

                }
            }
        }

        private void downSelect(Point pt)
        {
            int i, j, x, y;

            if (Undo.peek() != "Move")
                Undo.add(new ElemUndo(selectArea, clr, lyr, map, "Move"));

            if (selectArea.Width != 0 && selC[0][0] == -65281)
            {
                for (i = 0; i < selectArea.Width; i++)
                {
                    for (j = 0; j < selectArea.Height; j++)
                    {
                        if (i < LoadSave.W && j < LoadSave.H)
                        {
                            x = i + selectArea.X;
                            y = j + selectArea.Y;
                            selC[i][j] = clr[x][y];
                            selB[i][j] = map[x][y];
                            clr[x][y] = -1;
                            map[x][y].Data = map[x][y].ID = 0;
                            map[x][y].ent = null;
                            lyr[x][y] = 0;

                        }
                    }
                }
            }
        }

        private void upSelect(Point pt)
        {
            int i, j, x, y;

            if (selectArea.Width != 0)
            {
                for (i = 0; i < selectArea.Width; i++)
                {
                    for (j = 0; j < selectArea.Height; j++)
                    {
                        if (i < LoadSave.W && j < LoadSave.H)
                        {
                            x = i + selectArea.X;
                            y = j + selectArea.Y;
                            clr[x][y] = selC[i][j];
                            map[x][y] = selB[i][j];
                            lyr[x][y] = disp;
                            selC[i][j] = -65281;

                        }
                    }
                }
            }
        }

        private void moveSelect(Point pt, Point prev, MouseButtons e)
        {
            if (e == MouseButtons.Left)
            {
                clearSelect();

                selectArea.X += pt.X - prev.X;
                selectArea.Y += pt.Y - prev.Y;

                placeSelect();

                display.Image = img;

            }
        }

        private void clearSelect()
        {
            Point pt = Point.Empty;

            for (pt.X = selectArea.X; pt.X < selectArea.Right; pt.X++)
                for (pt.Y = selectArea.Y; pt.Y < selectArea.Bottom; pt.Y++)
                    if (pt.X < LoadSave.W && pt.Y < LoadSave.H)
                        setPixel(pt, clr[pt.X][pt.Y]);

        }

        private void placeSelect()
        {
            Point pt = Point.Empty;
            int i, j;

            for (pt.X = selectArea.X, i = 0; pt.X < selectArea.Right; pt.X++, i++)
                for (pt.Y = selectArea.Y, j = 0; pt.Y < selectArea.Bottom; pt.Y++, j++)
                    if (pt.X < LoadSave.W && pt.Y < LoadSave.H)
                        setPixel(pt, mixColor(selC[i][j], disp));

        }

        private void createCopy()
        {
            int i, j;

            if (resC == null ||
              (resC.Length != selC.Length ||
                resC[0].Length != selC[0].Length))
            {
                resB = new Block[selectArea.Width][];
                resC = new int[selectArea.Width][];

                GC.Collect();

                for (i = 0; i < selectArea.Width; i++)
                {
                    resB[i] = new Block[selectArea.Height];
                    resC[i] = new int[selectArea.Height];

                    for (j = 0; j < selectArea.Height; j++)
                    {
                        resC[i][j] = -65281;
                        resB[i][j] = new Block();

                    }
                }
            }
        }

        public void copy()
        {
            if (selectArea.Width != 0)
            {
                int i, j, x, y;

                createCopy();

                for (i = 0; i < selectArea.Width; i++)
                {
                    for (j = 0; j < selectArea.Height; j++)
                    {
                        x = i + selectArea.X;
                        y = j + selectArea.Y;
                        resC[i][j] = clr[x][y];
                        resB[i][j] = map[x][y];

                    }
                }
            }
        }

        public void cut()
        {
            if (selectArea.Width != 0)
            {
                int i, j;
                Point pt = selectArea.Location;

                Undo.add(new ElemUndo(selectArea, clr, lyr, map, "Cut"));

                createCopy();

                for (i = 0; i < selectArea.Width; i++)
                {
                    for (j = 0; j < selectArea.Height; j++)
                    {
                        pt.X = selectArea.X + i;
                        pt.Y = selectArea.Y + j;
                        resC[i][j] = clr[pt.X][pt.Y];
                        resB[i][j] = map[pt.X][pt.Y];
                        clr[pt.X][pt.Y] = -1;
                        map[pt.X][pt.Y].ID = map[pt.X][pt.Y].Data = 0;
                        map[pt.X][pt.Y].ent = null;
                        setPixel(pt, -1);

                    }
                }

                killSelect();

            }
        }

        public void paste()
        {
            if (resC != null)
            {
                Point pt = new Point((-display.Location.X + scl / 2) / scl,
                                     (-display.Location.Y + scl / 2) / scl);

                int x, y;

                Undo.add(new ElemUndo(selectArea, clr, lyr, map, "Paste"));
                killSelect();

                selectArea.Location = pt;
                selectArea.Size = new Size(resC.Length, resC[0].Length);

                createSelectMover();

                for (x = 0, pt.X = selectArea.X; x < selectArea.Width; x++, pt.X++)
                {
                    for (y = 0, pt.Y = selectArea.Y; y < selectArea.Height; y++, pt.Y++)
                    {
                        setPixel(pt, mixColor(resC[x][y], disp));
                        selC[x][y] = resC[x][y];
                        selB[x][y] = resB[x][y];

                    }
                }

                display.Image = img;

            }
        }

        public void flatten()
        {
            if (selC != null && selC[0][0] != -65281)
                upSelect(Point.Empty);

        }
    }
}
