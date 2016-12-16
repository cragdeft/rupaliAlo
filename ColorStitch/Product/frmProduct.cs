using ColorStitch.Model.Model;
using ColorStitch.Model.ModelDataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Infrastructure;
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
using ColorStitch.Services;
using ColorStitch.Services.ProductService;

namespace ColorStitch
{
    public partial class frmProduct : Form
    {

        #region Refresh Event for Parent
        public event System.EventHandler RefreshParent;
        #endregion

        public Product _product { get; set; }

        public FormDisplayType _displayType { get; set; }

        public frmProduct()
        {
            InitializeComponent();
        }

        public bool ShowDialog(Product oProduct, FormDisplayType displayType)
        {
            _displayType = displayType;

            switch (displayType)
            {
                case FormDisplayType.View:
                    ProductView(oProduct);
                    break;
                case FormDisplayType.Add:
                    ProductAdd(oProduct);
                    break;
                case FormDisplayType.Edit:
                    txtProductCode.Enabled = false;
                    ProductUpdate(oProduct);
                    break;
                case FormDisplayType.Delete:
                    ProductDelete(oProduct);
                    break;
                default:
                    break;
            }

            this.ShowDialog();
            return true;
        }

        private void ProductDelete(Product oProduct)
        {
            this.Text = "Delete product";
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            _product = oProduct;
            FillControls(oProduct);
        }

        private void ProductAdd(Product oProduct)
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            this.Text = "Add product";
            ClearControls();
        }

        private void ClearControls()
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
        }

        private void ProductView(Product oProduct)
        {
            btnUpdate.Visible = false;
            btnSave.Visible = false;
            btnDelete.Visible = false;
            this.Text = "View product";
            FillControls(oProduct);
        }

        private void ProductUpdate(Product oProduct)
        {
            this.Text = "Update product";
            btnSave.Visible = false;
            btnDelete.Visible = false;
            _product = oProduct;
            FillControls(oProduct);
        }

        private void FillControls(Product oProduct)
        {
            txtProductCode.Text = oProduct.ProductCode;
            txtProductName.Text = oProduct.ProductName;
            txtProductPrice.Text = oProduct.ProductPrice.ToString();
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                errorProvider1.SetError(txtProductName, "Enter product name");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtProductName, "");
            }

            if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                errorProvider1.SetError(txtProductCode, "Enter product code");
                return false;
            }


            if (txtProductPrice.Value == 0)
            {
                errorProvider1.SetError(txtProductPrice, "Enter product price");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtProductPrice, "");
            }

            if (_displayType == FormDisplayType.Add && errorProvider1.GetError(txtProductCode) != "")
            {
                return false;
            }


            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {


            if (IsValid())
            {
                Product product = FillObject(new Product());

                new ProductAddModificationService(product).Added();

                if (RefreshParent != null)
                {
                    RefreshParent(sender, e);

                }
                ClearControls();
            }

        }

        private Product FillObject(Product product)
        {

            product.ProductName = txtProductName.Text;
            product.ProductCode = txtProductCode.Text;
            product.ProductPrice = Convert.ToDecimal(txtProductPrice.Text);
            return product;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Product product = FillObject(_product);
                new ProductAddModificationService(product).Added();

                this.Close();
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            new ProductDeleteService(_product).Removed();
            this.Close();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            List<Product> productList = new ProductGetService(new Product()).GetsAlreadyExistProductCode(txtProductCode.Text);
            if (_displayType==FormDisplayType.Add && productList.Count > 0)
            {
                errorProvider1.SetError(txtProductCode, "Product code exist.");
            }
            else
            {
                errorProvider1.SetError(txtProductCode, "");
            }

        }


    }
}
