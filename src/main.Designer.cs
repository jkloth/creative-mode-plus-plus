using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;

namespace CreativeModePlus
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            int i;
            String fname = "CreativeModePlus.res.Minecraft-Icon.ico";
            Stream file = Asm.exe.GetManifestResourceStream(fname);
            Bitmap icon = new Bitmap(file);
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openMenu = new ToolStripMenuItem();
            exportMenu = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitMenu = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoMenu = new ToolStripMenuItem();
            redoMenu = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            deselMenu = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            copyMenu = new ToolStripMenuItem();
            cutMenu = new ToolStripMenuItem();
            pasteMenu = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            toolsMenu = new ToolStripMenuItem();
            mapToolStripMenuItem = new ToolStripMenuItem();
            regionMenu = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            aboutMenu = new ToolStripMenuItem();
            mnuScale = new ToolStripTextBox();
            height = new ComboBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            mnuLoad = new ToolStripProgressBar();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            mnuStatus = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            mnuBlock = new ToolStripStatusLabel();
            toolStripStatusLabel4 = new ToolStripStatusLabel();
            mnuCoord = new ToolStripStatusLabel();
            pnlImage = new Panel();
            mapImage = new PictureBox();
            cmbBlocks = new CreativeModePlus.ComboBoxWithIcons();
            cmbPaint = new CreativeModePlus.ComboBoxWithIcons();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(mapImage)).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.LightGray;
            menuStrip1.Items.AddRange(new ToolStripItem[] {
            fileToolStripMenuItem,
            editToolStripMenuItem,
            viewToolStripMenuItem,
            mapToolStripMenuItem,
            helpToolStripMenuItem,
            mnuScale});
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(528, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            openMenu,
            exportMenu,
            toolStripSeparator1,
            exitMenu});
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 23);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openMenu
            // 
            openMenu.Name = "openMenu";
            openMenu.ShortcutKeys = ((Keys)((Keys.Control | Keys.O)));
            openMenu.Size = new Size(182, 22);
            openMenu.Text = "&Open World";
            openMenu.Click += new EventHandler(openMenu_Click);
            // 
            // exportMenu
            // 
            exportMenu.Name = "exportMenu";
            exportMenu.ShortcutKeys = ((Keys)((Keys.Control | Keys.S)));
            exportMenu.Size = new Size(182, 22);
            exportMenu.Text = "&Save";
            exportMenu.Click += new EventHandler(exportMenu_Click);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(179, 6);
            // 
            // exitMenu
            // 
            exitMenu.Name = "exitMenu";
            exitMenu.ShortcutKeys = ((Keys)((Keys.Alt | Keys.F4)));
            exitMenu.Size = new Size(182, 22);
            exitMenu.Text = "E&xit";
            exitMenu.Click += new EventHandler(exitMenu_Click);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            undoMenu,
            redoMenu,
            toolStripSeparator2,
            deselMenu,
            toolStripSeparator3,
            copyMenu,
            cutMenu,
            pasteMenu});
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 23);
            editToolStripMenuItem.Text = "&Edit";
            //
            // deselMenu
            //
            deselMenu.Name = "deselMenu";
            deselMenu.ShortcutKeys = ((Keys)(Keys.Control | Keys.D));
            deselMenu.Size = new Size(152, 22);
            deselMenu.Text = "&Deselect";
            deselMenu.Click += new EventHandler(deselMenu_Click);
            // 
            // copyMenu
            // 
            copyMenu.Name = "copyMenu";
            copyMenu.ShortcutKeys = ((Keys)((Keys.Control | Keys.C)));
            copyMenu.Size = new Size(152, 22);
            copyMenu.Text = "C&opy";
            copyMenu.Click += new EventHandler(copyMenu_Click);
            // 
            // cutMenu
            // 
            cutMenu.Name = "cutMenu";
            cutMenu.ShortcutKeys = ((Keys)((Keys.Control | Keys.X)));
            cutMenu.Size = new Size(152, 22);
            cutMenu.Text = "C&ut";
            cutMenu.Click += new EventHandler(cutMenu_Click);
            // 
            // pasteMenu
            // 
            pasteMenu.Name = "pasteMenu";
            pasteMenu.ShortcutKeys = ((Keys)((Keys.Control | Keys.V)));
            pasteMenu.Size = new Size(152, 22);
            pasteMenu.Text = "&Paste";
            pasteMenu.Click += new EventHandler(pasteMenu_Click);
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.Add(toolsMenu);
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 23);
            viewToolStripMenuItem.Text = "&View";
            // 
            // toolsMenu
            // 
            toolsMenu.Checked = true;
            toolsMenu.CheckOnClick = true;
            toolsMenu.CheckState = CheckState.Checked;
            toolsMenu.Name = "toolsMenu";
            toolsMenu.Size = new Size(112, 22);
            toolsMenu.Text = "Tools";
            toolsMenu.CheckedChanged += new EventHandler(toolsMenu_CheckChanged);
            // 
            // mapToolStripMenuItem
            // 
            mapToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            regionMenu});
            mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            mapToolStripMenuItem.Size = new Size(43, 23);
            mapToolStripMenuItem.Text = "&Map";
            // 
            // regionMenu
            // 
            regionMenu.Name = "regionMenu";
            regionMenu.ShortcutKeys = ((Keys)((Keys.Control | Keys.R)));
            regionMenu.Size = new Size(186, 22);
            regionMenu.Text = "&Select Region";
            regionMenu.Click += new EventHandler(regionMenu_Click);
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            helpMenu, aboutMenu});
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 23);
            helpToolStripMenuItem.Text = "&Help";
            //
            // helpMenu
            //
            helpMenu.Name = "helpMenu";
            helpMenu.ShortcutKeys = Keys.F1;
            helpMenu.Size = new Size(149, 22);
            helpMenu.Text = "&Help";
            helpMenu.Click += new EventHandler(helpMenu_Click);
            // 
            // aboutMenu
            // 
            aboutMenu.Name = "aboutMenu";
            aboutMenu.ShortcutKeys = ((Keys)((Keys.Control | Keys.A)));
            aboutMenu.Size = new Size(149, 22);
            aboutMenu.Text = "&About";
            aboutMenu.Click += new EventHandler(aboutMenu_Click);
            // 
            // mnuScale
            // 
            mnuScale.BackColor = Color.LightGray;
            mnuScale.Name = "mnuScale";
            mnuScale.Size = new Size(50, 23);
            mnuScale.Text = "100%";
            mnuScale.TextBoxTextAlign = HorizontalAlignment.Right;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.LightGray;
            statusStrip1.Items.AddRange(new ToolStripItem[] {
            toolStripStatusLabel1,
            mnuLoad,
            toolStripStatusLabel2,
            mnuStatus,
            toolStripStatusLabel3,
            mnuBlock,
            toolStripStatusLabel4,
            mnuCoord});
            statusStrip1.Location = new Point(0, 601);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(528, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BackColor = Color.LightGray;
            toolStripStatusLabel1.Name = "toolStripStatusLabel";
            toolStripStatusLabel1.Size = new Size(22, 17);
            toolStripStatusLabel1.Text = "     ";
            // 
            // mnuLoad
            // 
            mnuLoad.BackColor = SystemColors.GrayText;
            mnuLoad.ForeColor = SystemColors.GradientActiveCaption;
            mnuLoad.Name = "mnuLoad";
            mnuLoad.Size = new Size(100, 16);
            mnuLoad.Style = ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.BackColor = Color.LightGray;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(22, 17);
            toolStripStatusLabel2.Text = "     ";
            // 
            // mnuStatus
            // 
            mnuStatus.BackColor = Color.LightGray;
            mnuStatus.Name = "mnuStatus";
            mnuStatus.Size = new Size(102, 17);
            mnuStatus.Text = "Not Loading";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.BackColor = Color.LightGray;
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(22, 17);
            toolStripStatusLabel3.Text = "     ";
            // 
            // mnuBlock
            // 
            mnuBlock.BackColor = Color.LightGray;
            mnuBlock.Name = "mnuBlock";
            mnuBlock.Size = new Size(102, 17);
            mnuBlock.Text = "Block Information";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel3.BackColor = Color.LightGray;
            toolStripStatusLabel3.Name = "toolStripStatusLabel4";
            toolStripStatusLabel3.Size = new Size(22, 17);
            toolStripStatusLabel3.Text = "     ";
            // 
            // mnuCoord
            // 
            mnuCoord.BackColor = Color.LightGray;
            mnuCoord.Name = "mnuBlock";
            mnuCoord.Size = new Size(102, 17);
            mnuCoord.Text = "( X, Y )";
            // 
            // pnlImage
            // 
            pnlImage.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                     | AnchorStyles.Left)
                     | AnchorStyles.Right)));
            pnlImage.AutoScroll = true;
            pnlImage.BackColor = SystemColors.Desktop;
            pnlImage.Controls.Add(mapImage);
            pnlImage.Location = new Point(0, 48);
            pnlImage.Name = "pnlImage";
            pnlImage.Size = new Size(528, 550);
            pnlImage.TabIndex = 4;
            pnlImage.MouseWheel += new MouseEventHandler(pnlImage_Wheel);
            // 
            // mapImage
            // 
            mapImage.Location = new Point(0, 0);
            mapImage.Name = "mapImage";
            mapImage.Size = new Size(512, 512);
            mapImage.SizeMode = PictureBoxSizeMode.Zoom;
            mapImage.TabIndex = 0;
            mapImage.TabStop = false;
            mapImage.MouseClick += new MouseEventHandler(mapImage_Click);
            mapImage.MouseDown += new MouseEventHandler(mapImage_Down);
            mapImage.MouseEnter += new EventHandler(mapImage_MouseEnter);
            mapImage.MouseLeave += new EventHandler(mapImage_MouseLeave);
            mapImage.MouseMove += new MouseEventHandler(mapImage_MouseMove);
            mapImage.MouseUp += new MouseEventHandler(mapImage_Up);
            // 
            // height
            // 
            height.DropDownStyle = ComboBoxStyle.DropDownList;
            height.FlatStyle = FlatStyle.Flat;
            height.Location = new Point(380, 27);
            height.Name = "height";
            height.Size = new Size(100, 21);
            height.TabIndex = 2;
            height.SelectedIndexChanged += new EventHandler(height_ValueChanged);
            // 
            // cmbBlocks
            // 
            cmbBlocks.DrawMode = DrawMode.OwnerDrawFixed;
            cmbBlocks.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBlocks.FlatStyle = FlatStyle.Flat;
            cmbBlocks.FormattingEnabled = true;
            cmbBlocks.Location = new Point(0, 27);
            cmbBlocks.Name = "cmbBlocks";
            cmbBlocks.Size = new Size(187, 21);
            cmbBlocks.TabIndex = 5;
            for (i = 0; i < 256; i++)
                height.Items.Add("" + (i + 1));
            cmbBlocks.SelectedIndexChanged += new EventHandler(cmbBlocks_SelectedIndexChanged);
            // 
            // cmbPaint
            // 
            cmbPaint.DrawMode = DrawMode.OwnerDrawFixed;
            cmbPaint.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaint.FlatStyle = FlatStyle.Flat;
            cmbPaint.FormattingEnabled = true;
            cmbPaint.Location = new Point(190, 27);
            cmbPaint.Name = "cmbPaint";
            cmbPaint.Size = new Size(187, 21);
            cmbPaint.TabIndex = 5;
            cmbPaint.SelectedIndexChanged += new EventHandler(cmbPaint_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(149, 6);
            // 
            // undoMenu
            // 
            undoMenu.Name = "undoMenu";
            undoMenu.ShortcutKeys = ((Keys)((Keys.Control | Keys.Z)));
            undoMenu.Size = new Size(152, 22);
            undoMenu.Text = "&Undo";
            undoMenu.Click += new EventHandler(undoMenu_Click);
            // 
            // redoMenu
            // 
            redoMenu.Name = "redoMenu";
            redoMenu.ShortcutKeys = ((Keys)((Keys.Control | Keys.Y)));
            redoMenu.Size = new Size(152, 22);
            redoMenu.Text = "&Redo";
            redoMenu.Click += new EventHandler(redoMenu_Click);
            // 
            // frmMain
            // 
            BackColor = Color.LightGray;
            ClientSize = new Size(528, 623);
            Controls.Add(cmbBlocks);
            Controls.Add(cmbPaint);
            Controls.Add(statusStrip1);
            Controls.Add(height);
            Controls.Add(menuStrip1);
            Controls.Add(pnlImage);
            FormClosing += new FormClosingEventHandler(frmMain_Closing);
            Icon = Icon.FromHandle(icon.GetHicon());
            file.Close();
            Location = new Point((Screen.PrimaryScreen.Bounds.Width - Width) / 2,
                                 (Screen.PrimaryScreen.Bounds.Height - Height) / 2);
            MainMenuStrip = menuStrip1;
            Move += new EventHandler(frmMain_SizeChanged);
            Name = "frmMain";
            StartPosition = FormStartPosition.Manual;
            Text = "Creative Mode+";
            SizeChanged += new EventHandler(frmMain_SizeChanged);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(mapImage)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openMenu;
        private ToolStripMenuItem exportMenu;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitMenu;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoMenu;
        private ToolStripMenuItem redoMenu;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem deselMenu;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem copyMenu;
        private ToolStripMenuItem cutMenu;
        private ToolStripMenuItem pasteMenu;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem toolsMenu;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem aboutMenu;
        private ToolStripMenuItem mapToolStripMenuItem;
        private ToolStripMenuItem regionMenu;
        private ToolStripProgressBar mnuLoad;
        private ToolStripTextBox mnuScale;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel mnuBlock;
        private ToolStripStatusLabel mnuCoord;
        private ToolStripStatusLabel mnuStatus;
        private ComboBox height;
        private Panel pnlImage;
        private ComboBoxWithIcons cmbBlocks;
        private PictureBox mapImage;

        public static ComboBoxWithIcons cmbPaint;

    }
}

