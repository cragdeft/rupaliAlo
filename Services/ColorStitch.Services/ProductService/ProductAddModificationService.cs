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
using ColorStitch.Services.ProductService;

namespace ColorStitch.Services
{
    public class ProductAddModificationService : IAddService<Product>
    {
        public Product _product { get; set; }
        public ProductAddModificationService(Product product)
        {
            _product = product;
        }

        public Product Added()
        {
            Product oProduct = new Product();
            oProduct = new ProductGetService(_product).GetProductByProductId();

            if (oProduct.ProductId > 0)
            {
                oProduct = new ProductModifiedService(_product).Modified();
            }
            else
            {
                oProduct = new ProductAddService(_product).Added();
            }

            return oProduct;
        }

        public Product GetProductByProductId(int ProductId)
        {
            Product oProduct = new Product();

            using (var context = new ColorStitchDataContext())
            {
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Product> productRepository = new Repository<Product>(context, unitOfWork);

                    oProduct = productRepository.Queryable().Where(p => p.ProductId == ProductId).FirstOrDefault();
                    if (oProduct == null)
                    {
                        oProduct = new Product();
                    }
                }
            }
            return oProduct;
        }

        

    }
}
