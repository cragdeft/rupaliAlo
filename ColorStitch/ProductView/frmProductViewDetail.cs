using ColorStitch.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorStitch.ProductView
{
    public partial class frmProductViewDetail : Form
    {
        #region Refresh Event for Parent
        public event System.EventHandler RefreshParent;
        #endregion

        public frmProductViewDetail()
        {
            InitializeComponent();
            gvProducts.AutoGenerateColumns = false;
            gvProductColor.AutoGenerateColumns = false;
        }

        public bool ShowDialog(Product oProduct, FormDisplayType displayType)
        {
            switch (displayType)
            {
                case FormDisplayType.View:
                    ProductView(oProduct);
                    break;
                case FormDisplayType.Add:
                    // ProductAdd(oProduct);
                    break;
                case FormDisplayType.Edit:
                    // ProductUpdate(oProduct);
                    break;
                case FormDisplayType.Delete:
                    // ProductDelete(oProduct);
                    break;
                default:
                    break;
            }

            this.ShowDialog();
            return true;
        }

        private void ProductView(Product oProduct)
        {
            FillProductWithData(oProduct);

            FillProductColorWithData(oProduct);

        }

        private void FillProductColorWithData(Product oProduct)
        {
            //gvProductColor.DataSource = oProduct.ProductColors;
            foreach (ProductColor item in oProduct.ProductColors)
            {
                int rowId = gvProductColor.Rows.Add();

                // Grab the new row!
                DataGridViewRow row = gvProductColor.Rows[rowId];

                // Add the data
                row.Cells["ColorName"].Value = item.ColorName;
                row.Cells["ProductQuantity"].Value = item.ProductQuantity;
                
            }

            gvProductColor.Refresh();
        }

        private void FillProductWithData(Product oProduct)
        {
            int rowId = gvProducts.Rows.Add();

            // Grab the new row!
            DataGridViewRow row = gvProducts.Rows[rowId];

            // Add the data
            row.Cells["ProductName"].Value = oProduct.ProductName;
            row.Cells["ProductCode"].Value = oProduct.ProductCode;
            row.Cells["ProductPrice"].Value = oProduct.ProductPrice;
            gvProducts.Refresh();
        }
    }
}
