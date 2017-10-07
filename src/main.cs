using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Substrate;
using Substrate.Core;
using Substrate.Data;

namespace CreativeModePlus
{
    using Properties;

    public partial class frmMain : Form
    {
        private Tools tools = null;
        private Point prev, prevScrl;
        private int prevVal;

        public static frmMain hInst;

        public frmMain()
        {
            int i;
            Stream file = null;
            String fname = "CreativeModePlus.res.block_icons.",
                   bname = "CreativeModePlus.res.brush.size.",
                   name;

            Asm.init();
            InitializeComponent();

            MessageBox.Show("This program saves changes to the world data every time" +
                         "\r\nthe region or layer changes in order to save memory.  If" +
                         "\r\nyou make changes that you wish to discard, please revert" +
                         "\r\nthem using Undo before moving on.",
                             "Please Note",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);

            tools = new Tools(this, mapImage);
            hInst = this;

            for (i = 0; i < 146; i++)
            {
                if (i != 95 && i != 36 && i != 34) // ignore certain block types
                {
                    file = Asm.exe.GetManifestResourceStream(fname + i + ".png");
                    name = ("" + ((BlockNames)i)).Replace('_', ' ');
                    cmbBlocks.Add(name, Image.FromStream(file), i);
                    file.Close();

                }

                if (i != 0 && i < 33)
                {
                    file = Asm.exe.GetManifestResourceStream(bname + i + "x" + i + ".png");
                    cmbPaint.Add("" + i, Image.FromStream(file), i - 1);
                    file.Close();

                }
            }

            prev = new Point(-1, -1);
            prevScrl = Point.Empty;

            cmbBlocks.SelectedIndex = cmbPaint.SelectedIndex = 0;

            prevVal = 62;
            height.SelectedIndex = 62;

            BlockColor.initBlockColors();

        }

        private void height_ValueChanged(object sender, EventArgs e)
        {
            if (LoadSave.Init &&
                !LoadSave.threadRunning &&
                height.SelectedIndex != prevVal)
            {
                prevVal = height.SelectedIndex;

                Undo.clear();

                LoadSave.changeLayer(false);

            }

            else if (height.SelectedIndex != prevVal)
                height.SelectedIndex = prevVal;

        }

        private void deselMenu_Click(object sender, EventArgs e)
        {
            if (Tools.Tool.Img != null &&
                !LoadSave.threadRunning)
                Tools.Tool.killSelect();

        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void frmMain_Closing(object sender, FormClosingEventArgs e)
        {
            if (LoadSave.threadRunning)
                LoadSave.killThread();

        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            new About(this).ShowDialog(this);

        }

        private void helpMenu_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("CMPHelp.pdf");

        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            if (LoadSave.threadRunning)
                LoadSave.killThread();

            LoadSave.openFile(tools, this, height, mnuLoad, mnuStatus);

        }

        private void exportMenu_Click(object sender, EventArgs e)
        {
            if (!LoadSave.threadRunning)
                LoadSave.save();

        }

        private void toolsMenu_CheckChanged(object sender, EventArgs e)
        {
            if (toolsMenu.Checked)
                tools.Show();

            else
                tools.Hide();

        }

        private void regionMenu_Click(object sender, EventArgs e)
        {
            if (!LoadSave.threadRunning)
                LoadSave.selectRegion(false);

        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (!tools.PositionChanged)
            {
                if (Width < 528)
                    tools.Location = new Point(Location.X + 12,
                                                Location.Y + Height - 143);

                else
                    tools.Location = new Point(Location.X + 12,
                                               Location.Y + Height - 142);

                tools.PositionChanged = false;

            }
        }

        private void pnlImage_Wheel(object sender, MouseEventArgs e)
        {
            Tools.Tool.scaleImage(e.Delta);

            mnuScale.Text = "" + (100 * Tools.Tool.Scale) + " %";

        }

        private void mapImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!LoadSave.threadRunning && Tools.Tool.Img != null)
                Tools.Tool.getBlockInfo(mnuBlock, e.Location);

            mnuCoord.Text = "( " + e.Location.X / Tools.Tool.Scale + ", " +
                                   e.Location.Y / Tools.Tool.Scale + " )";

            if (prev.X == -1)
                prev = e.Location;

            if (!LoadSave.threadRunning)
                Tools.doMove(Tools.Tool.adj(e.Location, true),
                              Tools.Tool.adj(prev, true),
                              e.Button);
            prev = e.Location;

        }

        private void mapImage_MouseEnter(object sender, EventArgs e)
        {
            pnlImage.AutoScrollOffset = prevScrl;

            if (!pnlImage.Focused)
                pnlImage.Focus();

            if (Tools.Initialized)
                Cursor = Tools.getCursor();

        }

        private void mapImage_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            mnuBlock.Text = "Block Information";

            if (Tools.Active == "Paint")
            {
                Point pt = Tools.Tool.adj(prev, true);

                if (Tools.Tool.Img != null)
                    Tools.Tool.placeCursor(pt, Tool.disp, 0, true);

            }

            prevScrl = pnlImage.AutoScrollOffset;

        }

        private void mapImage_Down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !LoadSave.threadRunning)
                Tools.doDown(Tools.Tool.adj(e.Location, false));

        }

        private void mapImage_Up(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !LoadSave.threadRunning)
                Tools.doUp(Tools.Tool.adj(e.Location, true));

        }

        private void mapImage_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !LoadSave.threadRunning)
                Tools.doClick(Tools.Tool.adj(e.Location, false));

        }

        private void copyMenu_Click(object sender, EventArgs e)
        {
            Tools.Tool.copy();

        }

        private void cutMenu_Click(object sender, EventArgs e)
        {
            Tools.Tool.cut();

        }

        private void pasteMenu_Click(object sender, EventArgs e)
        {
            if (LoadSave.Init)
            {
                Tools.selectTool("Move");
                Cursor = Tools.getCursor();
                Tools.Tool.paste();

            }
        }

        private void cmbBlocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem temp = ((ComboBoxItem)cmbBlocks.SelectedItem);

            Tools.Tool.setBlockType(temp.ID, this);

        }

        private void cmbPaint_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap temp = ((Bitmap)((ComboBoxItem)cmbPaint.SelectedItem).Img);

            Tools.Tool.resize(temp);

        }

        private void undoMenu_Click(object sender, EventArgs e)
        {
            Tools.Tool.undo();

        }

        private void redoMenu_Click(object sender, EventArgs e)
        {
            Tools.Tool.redo();

        }
    }
}
