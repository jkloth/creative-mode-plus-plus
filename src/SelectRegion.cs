using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Substrate;
using Substrate.Core;
using Substrate.Data;

namespace CreativeModePlus
{
    public partial class SelectRegion : Form
    {
        private int[] selected = null;

        public SelectRegion(AnvilRegionManager regs, Form main)
        {
            InitializeComponent(main);

            foreach (IRegion re in regs)
            {
                String insert = "Region ( " + re.X + ", " + re.Z + " )";
                cmbRegion.Items.Add(insert);

            }

            cmbRegion.SelectedIndex = 0;

        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int regX, regZ;

            String text = ((String)cmbRegion.SelectedItem);
            String[] vals = text.Split(", ".ToCharArray());
            regX = Int32.Parse(vals[2]);
            regZ = Int32.Parse(vals[4]);

            selected = new int[2];
            selected[0] = regX;
            selected[1] = regZ;

        }

        public int[] ShowDialog(bool sel)
        {
            btnCancel.Enabled = sel;

            if (ShowDialog() != DialogResult.OK)
                selected = null;

            return selected;

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }
    }
}
