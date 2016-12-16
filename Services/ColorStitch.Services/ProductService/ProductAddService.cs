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

namespace ColorStitch.Services
{
    public class ProductAddService : IAddService<Product>
    {
        public Product _product { get; private set; }
        public ProductAddService(Product product)
        {
            _product = product;
        }

        public Product Added()
        {
            Product oProduct = new Product();

            using (var context = new ColorStitchDataContext())
            {
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Product> productRepository = new Repository<Product>(context, unitOfWork);

                    oProduct = new Product
                    {
                        ProductName = _product.ProductName,
                        ProductCode = _product.ProductCode,
                        ProductPrice = _product.ProductPrice,
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
