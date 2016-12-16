using ColorStitch.Model.Model;
using ColorStitch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Services.ProductColorService
{

  public class ProductColorAddModificationService : IAddService<ProductColor>
  {
    public ProductColor _productColor { get; set; }
    public ProductColorAddModificationService(ProductColor productColor)
    {
      _productColor = productColor;
    }

    public ProductColor Added()
    {
      ProductColor oProductColor = new ProductColor();
      oProductColor = new ProductColorGetService(_productColor).GetColorByColorId();

      if (oProductColor.ProductColorId > 0)
      {
        oProductColor = new ProductColorModifiedService(_productColor).Modified();
      }
      else
      {
        oProductColor = new ProductColorAddService(_productColor).Added();
      }

      return oProductColor;
    }
  }
}
