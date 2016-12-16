using ColorStitch.Model.Model;
using ColorStitch.Services.ProductColorService;
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

namespace ColorStitch.ProductColorFrm
{
    public partial class frmProductColor : Form
    {
        #region Refresh Event for Parent
        public event System.EventHandler RefreshParent;
        #endregion

        public ProductColor _productColor { get; set; }
        public FormDisplayType _displayType { get; set; }

        public frmProductColor()
        {
            InitializeComponent();            
            FillCboProduct();
            cboProduct.SelectedIndex = 0;
            cboProduct.Refresh();
        }

        private void FillCboProduct()
        {
            cboProduct.DataSource = new ProductGetService(new Product()).GetsData();
            cboProduct.DisplayMember = "ProductName";
            cboProduct.ValueMember = "ProductId";
            cboProduct.SelectedIndex = 0;
            cboProduct.Refresh();
        }

        public bool ShowDialog(ProductColor oProductColor, FormDisplayType displayType)
        {
            _displayType = displayType;
            switch (displayType)
            {
                case FormDisplayType.View:
                    //ProductView(oProductColor);
                    break;
                case FormDisplayType.Add:
                    ProductAdd(oProductColor);
                    break;
                case FormDisplayType.Edit:
                    cboProduct.Enabled = false;
                    ProductUpdate(oProductColor);
                    break;
                case FormDisplayType.Delete:
                    // ProductDelete(oProductColor);
                    break;
                default:
                    break;
            }

            this.ShowDialog();
            return true;
        }

        private void ProductUpdate(ProductColor oProduct)
        {
            this.Text = "Update product color";
            btnSave.Visible = false;
            btnDelete.Visible = false;
            _productColor = oProduct;
            FillControls(oProduct);
        }

        private void FillControls(ProductColor oProduct)
        {
            txtProductColor.Text = oProduct.ColorName;
            txtProductQuantity.Value = oProduct.ProductQuantity;
            cboProduct.SelectedValue = oProduct.Product.ProductId;
        }

        private void ProductAdd(ProductColor oProductColor)
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            this.Text = "Add product color";
            ClearControls();
        }

        private void ClearControls()
        {
            cboProduct.SelectedIndex = -1;
            txtProductColor.Text = string.Empty;
            txtProductQuantity.Value = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                ProductColor productColor = FillObject(new ProductColor());

                new ProductColorAddModificationService(productColor).Added();

                if (RefreshParent != null)
                {
                    RefreshParent(sender, e);

                }
                ClearControls();
            }
        }

        private ProductColor FillObject(ProductColor productColor)
        {
            productColor.Product = GetProductEntity();
            productColor.ColorName = txtProductColor.Text;
            productColor.ProductQuantity = Convert.ToInt32(txtProductQuantity.Value);
            return productColor;
        }

        private Product GetProductEntity()
        {
            Product oProduct = new Product { ProductId = GetSelectedProductId() };

            return new ProductGetService(oProduct).GetProductByProductId();
        }

        private int GetSelectedProductId()
        {
            return Convert.ToInt32(cboProduct.SelectedValue);
        }

        private string GetSelectedProductName()
        {
            return cboProduct.SelectedText;
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(txtProductColor.Text))
            {
                errorProvider1.SetError(txtProductColor, "Enter product color");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtProductColor, "");
            }

            if (cboProduct.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboProduct, "Enter product");
                return false;
            }
            else
            {
                errorProvider1.SetError(cboProduct, "");
            }


            if (txtProductQuantity.Value == 0)
            {
                errorProvider1.SetError(txtProductQuantity, "Enter product quantity.");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtProductQuantity, "");
            }

            if (_displayType == FormDisplayType.Add && errorProvider1.GetError(txtProductQuantity) != "")
            {
                return false;
            }


            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                ProductColor product = FillObject(_productColor);
                new ProductColorAddModificationService(product).Added();

                this.Close();
            }

        }

        private void txtProductColor_TextChanged(object sender, EventArgs e)
        {
            //int productId = cboProduct.SelectedValue;
        }
    }
}
