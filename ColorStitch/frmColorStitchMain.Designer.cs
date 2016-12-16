namespace ColorStitch
{
    partial class frmColorStitchMain
    {
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmColorStitchMain));
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnProductColor = new System.Windows.Forms.Button();
            this.btnProductView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(14, 12);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(115, 78);
            this.btnProduct.TabIndex = 0;
            this.btnProduct.Text = "&Product";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnProductColor
            // 
            this.btnProductColor.Location = new System.Drawing.Point(152, 12);
            this.btnProductColor.Name = "btnProductColor";
            this.btnProductColor.Size = new System.Drawing.Size(115, 78);
            this.btnProductColor.TabIndex = 0;
            this.btnProductColor.Text = "Product &Color";
            this.btnProductColor.UseVisualStyleBackColor = true;
            this.btnProductColor.Click += new System.EventHandler(this.btnProductColor_Click);
            // 
            // btnProductView
            // 
            this.btnProductView.Location = new System.Drawing.Point(298, 12);
            this.btnProductView.Name = "btnProductView";
            this.btnProductView.Size = new System.Drawing.Size(115, 78);
            this.btnProductView.TabIndex = 0;
            this.btnProductView.Text = "Product &View";
            this.btnProductView.UseVisualStyleBackColor = true;
            this.btnProductView.Click += new System.EventHandler(this.btnProductView_Click);
            // 
            // frmColorStitchMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(896, 476);
            this.Controls.Add(this.btnProductView);
            this.Controls.Add(this.btnProductColor);
            this.Controls.Add(this.btnProduct);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmColorStitchMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Stitch Ltd.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnProductColor;
        private System.Windows.Forms.Button btnProductView;
    }
}