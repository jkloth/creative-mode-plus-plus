using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CreativeModePlus
{
    partial class AddData
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
        private void InitializeComponent(Form main)
        {
            IntPtr hThis;
            int items;
            btnData = new Button();
            SuspendLayout();
            // 
            // btnData
            // 
            btnData.DialogResult = DialogResult.OK;
            btnData.Location = new Point(12, 151);
            btnData.Name = "btnData";
            btnData.Size = new Size(75, 23);
            btnData.TabIndex = 8;
            btnData.Text = "Set Data";
            btnData.UseVisualStyleBackColor = true;
            // 
            // AddData
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(194, 186);
            Controls.Add(btnData);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Location = new Point(main.Location.X + 12, main.Location.Y + 83);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddData";
            StartPosition = FormStartPosition.Manual;
            Text = "AddData";
            ResumeLayout(false);

            hThis = GetSystemMenu(this.Handle, false);
            items = GetMenuItemCount(hThis);
            RemoveMenu(hThis, items - 1, 0x400);

        }

        #endregion

        private Button btnData;
    }
}