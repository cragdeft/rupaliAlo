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

  public class ProductColorModifiedService : IModificationService<ProductColor>
  {
    public ProductColor _productColor { get; set; }
    public ProductColorModifiedService(ProductColor productColor)
    {
      _productColor = productColor;
    }

    public ProductColor Modified()
    {
      ProductColor oProductEntity = new ProductColor();
      using (var context = new ColorStitchDataContext())
      {
        using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
        {
          IRepositoryAsync<ProductColor> productRepository = new Repository<ProductColor>(context, unitOfWork);
          oProductEntity = new ProductColorGetService(_productColor).GetColorByColorId();


          oProductEntity.Product = _productColor.Product;
          oProductEntity.ColorName = _productColor.ColorName;
          oProductEntity.ProductQuantity = _productColor.ProductQuantity;
          oProductEntity.ObjectState = ObjectState.Modified;


          productRepository.Update(oProductEntity);
          unitOfWork.SaveChanges();
        }
      }
      return oProductEntity;
    }
  }


}
