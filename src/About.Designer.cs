using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CreativeModePlus
{
    partial class About
    {
        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr menu, int pos, int flags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr win, bool revert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr win);

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
        private void InitializeComponent(Form parent)
        {
            String fname = "CreativeModePlus.res.Logo.png";
            Stream file = Asm.exe.GetManifestResourceStream(fname);
            IntPtr hThis;
            int items;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            aboutLbl = new Label();
            pictureBox1 = new PictureBox();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            SuspendLayout();
            // 
            // aboutLbl
            // 
            aboutLbl.AutoSize = true;
            aboutLbl.Location = new Point(193, 12);
            aboutLbl.Name = "aboutLbl";
            aboutLbl.Size = new Size(343, 182);
            aboutLbl.TabIndex = 0;
            aboutLbl.Text = resources.GetString("aboutLbl.Text");
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Image = new Bitmap(file);
            pictureBox1.Size = new Size(175, 175);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            file.Close();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(407, 161);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(118, 26);
            btnOk.TabIndex = 2;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += new EventHandler(btnOk_Click);
            // 
            // About
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 199);
            Controls.Add(btnOk);
            Controls.Add(pictureBox1);
            Controls.Add(aboutLbl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Location = new Point(parent.Location.X + 12, parent.Location.Y + 83);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            StartPosition = FormStartPosition.Manual;
            Text = "About          Creative Mode Plus, Ver: " + Asm.ver.ToString();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ResumeLayout(false);
            PerformLayout();

            hThis = GetSystemMenu(this.Handle, false);
            items = GetMenuItemCount(hThis);
            RemoveMenu(hThis, items - 1, 0x400);

        }

        #endregion

        private Label aboutLbl;
        private PictureBox pictureBox1;
        private Button btnOk;

    }
}