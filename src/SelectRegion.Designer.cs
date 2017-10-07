using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CreativeModePlus
{
    partial class SelectRegion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectRegion));
            label1 = new Label();
            cmbRegion = new ComboBox();
            btnSelect = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(118, 13);
            label1.TabIndex = 0;
            label1.Text = "Select a Region to edit:";
            // 
            // cmbRegion
            // 
            cmbRegion.FormattingEnabled = true;
            cmbRegion.Location = new Point(12, 32);
            cmbRegion.Name = "cmbRegion";
            cmbRegion.Size = new Size(183, 21);
            cmbRegion.TabIndex = 1;
            cmbRegion.SelectedIndexChanged += new EventHandler(cmbRegion_SelectedIndexChanged);
            // 
            // btnSelect
            // 
            btnSelect.Click += new EventHandler(btnSelect_Click);
            btnSelect.Location = new Point(12, 59);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(75, 23);
            btnSelect.TabIndex = 2;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(120, 59);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // SelectRegion
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(207, 92);
            Controls.Add(btnCancel);
            Controls.Add(btnSelect);
            Controls.Add(cmbRegion);
            Controls.Add(label1);
            AcceptButton = btnSelect;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = ((Icon)(resources.GetObject("$Icon")));
            Location = new Point(main.Location.X + 12, main.Location.Y + 83);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectRegion";
            StartPosition = FormStartPosition.Manual;
            Text = "Select a Region";
            ResumeLayout(false);
            PerformLayout();

            hThis = GetSystemMenu(this.Handle, false);
            items = GetMenuItemCount(hThis);
            RemoveMenu(hThis, items - 1, 0x400);

        }

        #endregion

        private Label label1;
        private ComboBox cmbRegion;
        private Button btnSelect;
        private Button btnCancel;
    }
}