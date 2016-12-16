using ColorStitch.Model.Model;
using ColorStitch.Model.ModelDataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorStitch.Services.ProductService;

namespace ColorStitch
{
    public partial class frmProductParent : Form
    {
        public int SelectedRowIndex { get; set; }
        

        public frmProductParent()
        {
            InitializeComponent();
            gvProducts.AutoGenerateColumns = false;            
            RefreshList();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewProduct();

        }

        private void ViewProduct()
        {
            frmProduct ofrmProduct = new frmProduct();
            ofrmProduct.RefreshParent += new System.EventHandler(this.RefreshParent);

            Product oProduct = GetSelectedRowRecords();

            if (ofrmProduct.ShowDialog(oProduct, FormDisplayType.View))
            {
                RefreshList();
            }
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
                btnEdit.Enabled = (totalRow > 0);
                btnDelete.Enabled = (totalRow > 0);

            }
            else
            {
                lblTotalRecord.Text = "Total :: ";
                btnView.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }

            RefreshGrid(productList);

        }

        private void RefreshParent(object sender, System.EventArgs e)
        {
            RefreshList();
            this.Refresh();
        }



        private void gvProducts_SelectionChanged(object sender, EventArgs e)
        {
            SelectedRowIndex = gvProducts.CurrentCell.RowIndex;
        }

        private void gvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewProduct();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProduct ofrmProduct = new frmProduct();
            ofrmProduct.RefreshParent += new System.EventHandler(this.RefreshParent);


            if (ofrmProduct.ShowDialog(new Product(), FormDisplayType.Add))
            {
                RefreshList();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmProduct ofrmProduct = new frmProduct();
            ofrmProduct.RefreshParent += new System.EventHandler(this.RefreshParent);

            Product oProduct = GetSelectedRowRecords();

            if (ofrmProduct.ShowDialog(oProduct, FormDisplayType.Edit))
            {
                RefreshList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmProduct ofrmProduct = new frmProduct();
            ofrmProduct.RefreshParent += new System.EventHandler(this.RefreshParent);

            Product oProduct = GetSelectedRowRecords();

            if (ofrmProduct.ShowDialog(oProduct, FormDisplayType.Delete))
            {
                RefreshList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            Product oProduct = new Product();
            oProduct.ProductCode = txtSearch.Text;

            var productList = new ProductGetService(oProduct).GetsProductByCode();

            RefreshGrid(productList);
        }

        private void RefreshGrid(List<Product> productList)
        {
            gvProducts.DataSource = productList;
            gvProducts.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}
