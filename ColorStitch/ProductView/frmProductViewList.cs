using ColorStitch.Entity;
using ColorStitch.Model.Model;
using ColorStitch.Services.ProductService;
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
    public partial class frmProductViewList : Form
    {
        public int SelectedRowIndex { get; set; }

        public frmProductViewList()
        {
            InitializeComponent();
            gvProducts.AutoGenerateColumns = false;
            RefreshList();
        }

        private void RefreshList()
        {
            List<Product> productList = new ProductGetService(new Product()).GetsData();
            txtSearch.Text = string.Empty;

            int totalRow = productList.Count;
            if (totalRow > 0)
            {
                lblTotalRecord.Text = "Total :: " + totalRow;
                lblTotalRecord.BackColor = System.Drawing.Color.AliceBlue;

                btnView.Enabled = (totalRow > 0);


            }
            else
            {
                lblTotalRecord.Text = "Total :: ";
                btnView.Enabled = false;

            }

            RefreshGrid(productList);
        }

        private void RefreshGrid(List<Product> productList)
        {
            gvProducts.DataSource = productList;
            gvProducts.Refresh();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewProduct();
        }

        private void ViewProduct()
        {
            frmProductViewDetail ofrmProduct = new frmProductViewDetail();
            ofrmProduct.RefreshParent += new System.EventHandler(this.RefreshParent);

            Product oProduct = GetSelectedRowRecords();
            Product ProductEntity = new Product();

            ProductEntity = new ProductGetService(oProduct).GetProductByProductId();

            if (ofrmProduct.ShowDialog(ProductEntity, FormDisplayType.View))
            {
                RefreshList();
            }
        }

        private void RefreshParent(object sender, System.EventArgs e)
        {
            RefreshList();
            this.Refresh();
        }

        private Product GetSelectedRowRecords()
        {
            DataGridViewRow row = gvProducts.Rows[SelectedRowIndex];

            Product oProduct = new Product();
            oProduct.ProductId = Convert.ToInt32(row.Cells["ProductId"].Value.ToString());
            oProduct.ProductName = row.Cells["ProductName"].Value.ToString();
            oProduct.ProductCode = row.Cells["ProductCode"].Value.ToString();
            oProduct.ProductPrice = Convert.ToDecimal(row.Cells["ProductPrice"].Value.ToString());
            return oProduct;

        }

        private void gvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewProduct();
        }

        private void gvProducts_SelectionChanged(object sender, EventArgs e)
        {
            SelectedRowIndex = gvProducts.CurrentCell.RowIndex;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Product oProduct = new Product();
            oProduct.ProductName = txtSearch.Text;
            List<Product> productList = new ProductGetService(oProduct).GetsProductByName();
            gvProducts.DataSource = productList;
            gvProducts.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        
    }
}
