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
    public class ProductDeleteService : IDeleteService<Product>
    {
        public Product _product { get; set; }
        public ProductDeleteService(Product product)
        {
            _product = product;
        }
        public Product Removed()
        {
            Product oProduct = new Product();
            oProduct = new ProductAddModificationService(_product).GetProductByProductId(_product.ProductId);
            if (oProduct.ProductId > 0)
            {
                using (var context = new ColorStitchDataContext())
                {


                    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                    {
                        IRepositoryAsync<Product> productRepository = new Repository<Product>(context, unitOfWork);
                        productRepository.Delete(_product);
                        unitOfWork.SaveChanges();
                    }
                }
            }
            return oProduct;
        }
    }
}
