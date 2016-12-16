using ColorStitch.Model.Model;
using ColorStitch.Model.ModelDataContext;
using ColorStitch.Services.Interfaces;
using ColorStitch.Services.ProductService;
using Repository.Pattern.Ef6;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Services
{
  public class ProductModifiedService : IModificationService<Product>
  {
    public Product _product { get; set; }
    public ProductModifiedService(Product product)
    {
      _product = product;
    }

    public Product Modified()
    {
      Product oProductEntity = new Product();
      using (var context = new ColorStitchDataContext())
      {
        using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
        {
          IRepositoryAsync<Product> productRepository = new Repository<Product>(context, unitOfWork);
          oProductEntity = new ProductGetService(_product).GetProductByProductId();


          oProductEntity.ProductName = _product.ProductName;
          oProductEntity.ProductCode = _product.ProductCode;
          oProductEntity.ProductPrice = _product.ProductPrice;
          oProductEntity.ObjectState = ObjectState.Modified;


          productRepository.Update(oProductEntity);
          unitOfWork.SaveChanges();
        }
      }
      return oProductEntity;
    }
  }
}
