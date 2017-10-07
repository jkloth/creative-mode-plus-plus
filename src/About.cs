using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CreativeModePlus
{
    public partial class About : Form
    {
        public About(Form parent)
        {
            InitializeComponent(parent);

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }
    }
}
