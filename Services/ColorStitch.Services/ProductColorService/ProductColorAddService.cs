using ColorStitch.Model.Model;
using ColorStitch.Model.ModelDataContext;
using ColorStitch.Services.Interfaces;
using Repository.Pattern.Ef6;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Services.ProductColorService
{

  public class ProductColorAddService : IAddService<ProductColor>
  {
    public ProductColor _productColor { get; private set; }
    public ProductColorAddService(ProductColor productColor)
    {
      _productColor = productColor;
    }

    public ProductColor Added()
    {
      ProductColor oProduct = new ProductColor();

      using (var context = new ColorStitchDataContext())
      {
        using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
        {
          IRepositoryAsync<ProductColor> productRepository = new Repository<ProductColor>(context, unitOfWork);

          oProduct = new ProductColor
          {
            Product = _productColor.Product,
            ColorName = _productColor.ColorName,
            ProductQuantity = _productColor.ProductQuantity,
            ObjectState = ObjectState.Added,
          };

          productRepository.Insert(oProduct);
          unitOfWork.SaveChanges();
        }
      }
      return oProduct;
    }
  }


}
