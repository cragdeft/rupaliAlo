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
using ColorStitch.Services.ProductColorService;
using ColorStitch.Entity;

namespace ColorStitch.ProductColorFrm
{
    public partial class frmProductColorParent : Form
    {
        public int SelectedRowIndex { get; set; }
        public frmProductColorParent()
        {
            InitializeComponent();
            gvProducts.AutoGenerateColumns = false;
            RefreshList();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductColor ofrmProductColor = new frmProductColor();
            ofrmProductColor.RefreshParent += new System.EventHandler(this.RefreshParent);


            if (ofrmProductColor.ShowDialog(new ProductColor(), FormDisplayType.Add))
            {
                RefreshList();
            }
        }

        private void RefreshParent(object sender, System.EventArgs e)
        {
            RefreshList();
            this.Refresh();
        }


        private void RefreshList()
        {

            List<ProductColorEntity> productColorList = new ProductColorGetService(new ProductColor()).GetsColorEntityData();
            txtSearch.Text = string.Empty;

            int totalRow = productColorList.Count;
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

            RefreshGrid(productColorList);

        }

        private void RefreshGrid(List<ProductColorEntity> productList)
        {
            gvProducts.DataSource = productList;
            gvProducts.Refresh();
        }

        private void gvProducts_SelectionChanged(object sender, EventArgs e)
        {
            SelectedRowIndex = gvProducts.CurrentCell.RowIndex;
        }

        private void gvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ViewProduct();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmProductColor ofrmProductColor = new frmProductColor();
            ofrmProductColor.RefreshParent += new System.EventHandler(this.RefreshParent);

            ProductColor oProduct = GetSelectedRowRecords();

            if (ofrmProductColor.ShowDialog(oProduct, FormDisplayType.Edit))
            {
                RefreshList();
            }
        }

        private ProductColor GetSelectedRowRecords()
        {
            DataGridViewRow row = gvProducts.Rows[SelectedRowIndex];

            ProductColor oProduct = new ProductColor();
            oProduct.Product = new Product();

            oProduct.Product.ProductId = Convert.ToInt32(row.Cells["ProductId"].Value.ToString());
            oProduct.ProductColorId = Convert.ToInt32(row.Cells["ProductColorId"].Value.ToString());
            oProduct.ColorName = row.Cells["ColorName"].Value.ToString();
            oProduct.ProductQuantity = Convert.ToInt32(row.Cells["ProductQuantity"].Value);
            return oProduct;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //ColorStitch.Services.ProductColorService
            // ProductColorDeleteService

            ProductColor oProduct = GetSelectedRowRecords();
            new ProductColorDeleteService(oProduct).Removed();

            RefreshList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductColor oColor = new ProductColor();
            oColor.ColorName = txtSearch.Text;
            List<ProductColor> colorList = new ProductColorGetService(oColor).GetsColorByColorName();
            List<ProductColorEntity> colorEntityList = new ProductColorGetService(oColor).FillColorEntity(colorList);
            RefreshGrid(colorEntityList);
        }
    }
}
