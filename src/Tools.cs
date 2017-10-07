using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreativeModePlus
{
    public delegate void DoMove(Point pt, Point prev, MouseButtons mb);
    public delegate void DoDown(Point pt);
    public delegate void DoUp(Point pt);
    public delegate void DoClick(Point pt);

    public partial class Tools : Form
    {
        private static Tools hThis = null;
        private static Tool use = null;
        private static String cName = "";
        private static String name = "";
        private static bool initialized = false;
        private static DoMove moveTool;
        private static DoDown downTool;
        private static DoUp upTool;
        private static DoClick clickTool;

        private bool moved;

        public static Tool Tool { get { return use; } }
        public static bool Initialized { get { return initialized; } }
        public static Point Origin { get { return use.Area.Location; } }
        public static String Active { get { return name; } }
        public static DoMove doMove { get { return moveTool; } }
        public static DoDown doDown { get { return downTool; } }
        public static DoUp doUp { get { return upTool; } }
        public static DoClick doClick { get { return clickTool; } }

        public bool PositionChanged { get { return moved; } set { moved = value; } }

        public static Cursor getCursor()
        {
            Cursor toRet = Cursors.Default;

            if (cName.Length != 0)
            {
                Bitmap temp = new Bitmap(Asm.exe.GetManifestResourceStream(cName));
                toRet = new Cursor(temp.GetHicon());

            }

            return toRet;

        }

        private static void init(PictureBox pic)
        {
            use = new Tool(pic);
            moveTool = use.getMove("");
            clickTool = use.getClick("");
            downTool = use.getDown("");
            upTool = use.getUp("");

            initialized = true;

        }

        private static void changeTool(Button pressed)
        {
            if (name == "Move")
                use.flatten();

            switch (pressed.Name)
            {
                case "btnSelect":
                    cName = "CreativeModePlus.res.brush.General.png";
                    name = "Select";

                    break;

                case "btnMove":
                    cName = "CreativeModePlus.res.brush.MoveSelect.png";
                    name = "Move";

                    break;

                case "btnFill":
                    cName = "CreativeModePlus.res.brush.General.png";
                    name = "Fill";

                    break;

                case "btnPaint":
                    cName = "CreativeModePlus.res.brush.General.png";
                    name = "Paint";

                    break;

                case "btnPencil":
                    cName = "CreativeModePlus.res.brush.Pencil.png";
                    name = "Pencil";

                    frmMain.cmbPaint.SelectedIndex = 0;

                    break;

            }

            if (name != "Pencil")
                frmMain.cmbPaint.Enabled = true;

            else
                frmMain.cmbPaint.Enabled = false;

            moveTool = use.getMove(name);
            downTool = use.getDown(name);
            upTool = use.getUp(name);
            clickTool = use.getClick(name);

        }

        public static void selectTool(String btn)
        {
            Button click = null;

            switch (btn)
            {
                case "Move":
                    click = hThis.btnMove;

                    break;

            }

            click.Select();
            changeTool(click);

        }

        public Tools(Form main, PictureBox pic)
        {
            InitializeComponent(main);

            CheckForIllegalCrossThreadCalls = false;

            if (!initialized)
                init(pic);

            hThis = this;

            Show();

            moved = false;

        }

        protected override void OnMove(EventArgs e)
        {
            moved = true;

            base.OnMove(e);

        }

        private void Tools_Activated(object sender, EventArgs e)
        {
            Opacity = 1.0;

        }

        private void Tools_Deactivate(object sender, EventArgs e)
        {
            Opacity = 0.75;

        }

        private void btn_Pressed(object sender, EventArgs e)
        {
            changeTool((Button)sender);

        }
    }
}
