using Substrate;
using Substrate.Core;
using Substrate.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CreativeModePlus
{
    class LoadSave
    {
        private static bool init;
        private static bool needSave;
        private static ComboBox mnuHeight;
        private static ToolStripProgressBar mnuLoad;
        private static ToolStripStatusLabel mnuStatus;
        private static SelectRegion regDiag;

        private static Thread thread = null;

        private static AnvilWorld lvl = null;
        private static AnvilRegion reg = null;

        private static int[] region = null;
        private static int[] pReg = null;
        private static int y,
                              cxd,
                              czd,
                              xd,
                              zd,
                              wid,
                              hgt;

        public static int W { get { return wid; } }
        public static int H { get { return hgt; } }
        public static bool threadRunning
        {
            get
            {
                return (thread != null && thread.ThreadState == ThreadState.Running);

            }
        }
        public static bool Init { get { return init; } }

        public static void openFile(Form plcType,
                                     Form main,
                                     ComboBox height,
                                     ToolStripProgressBar mLoad,
                                     ToolStripStatusLabel mStatus)
        {
            bool noFile = true, cancel = false;
            OpenFileDialog openDiag;
            DialogResult res;
            String filename;

            mnuHeight = height;
            mnuLoad = mLoad;
            mnuStatus = mStatus;
            init = true;

            plcType.Hide();

            while (noFile ^ cancel)
            {
                openDiag = new OpenFileDialog();
                openDiag.Multiselect = false;
                openDiag.AddExtension = true;
                openDiag.DefaultExt = "dat";
                openDiag.Filter = "Minecraft Levels (*.dat)|*.dat|" +
                                        "All Files (*.*)|*.*";

                res = openDiag.ShowDialog();

                plcType.Show();

                if (res == DialogResult.Cancel)
                    cancel = true;

                else
                {
                    filename = openDiag.FileName;

                    noFile = false;
                    openDiag.Dispose();

                    lvl = AnvilWorld.Open(filename);

                    if (lvl == null)
                        MessageBox.Show("That file was not a compatible Minecraft level.",
                                         "Open File Error",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);

                    else
                    {
                        regDiag = new SelectRegion(lvl.GetRegionManager(), main);
                        loadLimits();
                        selectRegion(true);

                    }
                }
            }
        }

        private static void loadLimits()
        {
            cxd = czd = 32;
            xd = zd = 16;
            wid = hgt = 512;

            mnuLoad.Maximum = 262144;

            startThread(RunThread.Init);

        }

        public static void save()
        {
            if (reg != null)
            {
                Undo.clear();

                startThread(RunThread.SaveLayer);

                lvl.Save();

            }
        }

        public static void selectRegion(bool first)
        {
            region = regDiag.ShowDialog(reg != null);

            if (region != null)
            {
                pReg = region;

                changeLayer(first);

            }

            else
                region = pReg;

        }

        public static void changeLayer(bool first)
        {
            needSave = !first;

            startThread(RunThread.LoadLayer);

        }

        public static void startThread(RunThread run)
        {
            if (thread != null)
                thread.Join();

            switch (run)
            {
                case RunThread.Init:
                    thread = new Thread(new ThreadStart(loadMaps));

                    break;

                case RunThread.LoadLayer:
                    thread = new Thread(new ThreadStart(loadLayers));

                    break;

                case RunThread.Update:
                    thread = new Thread(new ThreadStart(loadImage));

                    break;

                case RunThread.SaveLayer:
                    thread = new Thread(new ThreadStart(saveLayers));

                    break;

            }

            if (thread != null)
                thread.Start();

        }

        public static void killThread()
        {
            try
            {
                thread.Abort();

            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString(),
                                 "Stopping Threads",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);

            }
        }

        private static void loadMaps()
        {
            Limits l = new Limits();

            int x;

            mnuStatus.Text = "Creating Map Storage";
            mnuLoad.Increment(-1 * hgt * wid);

            l.clr = new int[wid][];
            l.lyr = new int[wid][];
            l.map = new Block[wid][];

            for (x = 0; x < wid; x++)
            {
                l.clr[x] = new int[hgt];
                l.lyr[x] = new int[hgt];
                l.map[x] = new Block[hgt];

                mnuLoad.Increment(hgt);

            }

            mnuLoad.Increment(-hgt * wid);
            mnuStatus.Text = "Not Loading";

            Tools.Tool.finishLimits(l);

        }

        private static void loadLayers()
        {
            AlphaBlockCollection blk = null;
            int x, z, cx, cz, mx, mz, id;

            if (needSave)
                saveLayers();

            reg = ((AnvilRegion)
                       lvl.GetRegionManager().GetRegion(region[0], region[1]));
            mnuStatus.Text = "Loading Block Data";

            needSave = false;
            y = mnuHeight.SelectedIndex;

            for (cx = 0; cx < cxd; cx++)
            {
                for (cz = 0; cz < czd; cz++)
                {
                    if (reg.ChunkExists(cx, cz))
                        blk = reg.GetChunkRef(cx, cz).Blocks;

                    else
                        blk = null;

                    for (x = 0; x < xd; x++)
                    {
                        for (z = 0; z < zd; z++)
                        {
                            mx = cx * xd + x;
                            mz = cz * zd + z;
                            if (blk != null)
                            {
                                id = Tools.Tool.Map[mx][mz].ID = blk.GetID(x, y, z);
                                Tools.Tool.Map[mx][mz].Data = blk.GetData(x, y, z);
                                Tools.Tool.Map[mx][mz].ent = blk.GetTileEntity(x, y, z);

                            }

                            else
                                id = Tools.Tool.Map[mx][mz].ID = -1;
                            Tools.Tool.Clr[mx][mz] = BlockColor.getBlockColor(id);

                        }
                    }

                    mnuLoad.Increment(xd * zd);

                }
            }
            mnuLoad.Increment(-hgt * wid);

            loadImage();

        }

        private static void loadImage()
        {
            int X, Y;
            Bitmap img = new Bitmap(wid, hgt);
            Rectangle rect = new Rectangle(0, 0, wid, hgt);
            BitmapData imgChange =
             img.LockBits(rect, ImageLockMode.ReadWrite, img.PixelFormat);

            mnuStatus.Text = "Rendering Image";

            unsafe
            {
                int* chg = ((int*)imgChange.Scan0);

                for (Y = 0; Y < hgt; Y++)
                {
                    for (X = 0; X < wid; X++)
                        chg[Y * wid + X] = Tools.Tool.mixColor(Tools.Tool.Clr[X][Y],
                                                                  Tools.Tool.Lyr[X][Y]);

                }
            }

            img.UnlockBits(imgChange);

            Tools.Tool.showImage(img);

            mnuStatus.Text = "Not Loading";

        }

        private static void saveLayers()
        {
            AlphaBlockCollection chk = null;
            int x, z, cx, cz, ax, az;

            mnuStatus.Text = "Saving Block Data";

            for (cx = 0; cx < cxd; cx++)
            {
                for (cz = 0; cz < czd; cz++)
                {
                    if (reg.ChunkExists(cx, cz))
                    {
                        chk = reg.GetChunkRef(cx, cz).Blocks;

                        for (x = 0; x < xd; x++)
                        {
                            for (z = 0; z < zd; z++)
                            {
                                ax = cx * xd + x;
                                az = cz * zd + z;
                                chk.SetBlock(x,
                                              y,
                                              z,
                                              new AlphaBlock(Tools.Tool.Map[ax][az].ID,
                                                              Tools.Tool.Map[ax][az].Data));
                                if (Tools.Tool.Map[ax][az].ent != null)
                                    chk.SetTileEntity(x, y, z, Tools.Tool.Map[ax][az].ent);

                            }
                        }

                        mnuLoad.Increment(xd * zd);
                        reg.Save();

                    }
                }
            }

            GC.Collect();

            mnuLoad.Increment(-hgt * wid);
            mnuStatus.Text = "Not Loading";

        }
    }
}
