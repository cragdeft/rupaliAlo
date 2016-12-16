using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorStitch.ProductColorFrm;
using ColorStitch.ProductView;

namespace ColorStitch
{
    public partial class frmColorStitchMain : Form
    {
        public frmColorStitchMain()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProductParent ofrmProduct = new frmProductParent();
            ofrmProduct.ShowDialog();
        }

        private void btnProductColor_Click(object sender, EventArgs e)
        {
            frmProductColorParent color = new frmProductColorParent();
            color.ShowDialog();
        }

        private void btnProductView_Click(object sender, EventArgs e)
        {
            frmProductViewList productView = new frmProductViewList();
            productView.ShowDialog();
        }
    }
}
