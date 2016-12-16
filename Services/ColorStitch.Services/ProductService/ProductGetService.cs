using ColorStitch.Model.Model;
using ColorStitch.Model.ModelDataContext;
using ColorStitch.Services.Interfaces;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Services.ProductService
{
    public class ProductGetService : IProductGetService<Product>
    {
        public Product _product { get; set; }
        public ProductGetService(Product product)
        {
            _product = product;
        }

        public Product GetProductByProductId()
        {
            Product oProduct = new Product();

            using (var context = new ColorStitchDataContext())
            {
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Product> productRepository = new Repository<Product>(context, unitOfWork);

                    oProduct = productRepository.Queryable().Where(p => p.ProductId == _product.ProductId).Include(x => x.ProductColors).FirstOrDefault();
                    if (oProduct == null)
                    {
                        oProduct = new Product();
                    }
                }
            }
            return oProduct;
        }

        public List<Product> GetsData()
        {
            List<Product> productList = new List<Product>();

            using (var context = new ColorStitchDataContext())
            {
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Product> productRepository = new Repository<Product>(context, unitOfWork);

                    productList = productRepository.Queryable().Include(x => x.ProductColors).ToList();
                    if (productList == null)
                    {
                        productList = new List<Product>();
                    }
                }
            }
            return productList;
        }

        public List<Product> GetsProductByCode()
        {
            List<Product> productList = new List<Product>();

            using (var context = new ColorStitchDataContext())
            {
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Product> productRepository = unitOfWork.RepositoryAsync<Product>();

                    productList = productRepository.Queryable().Where(p => p.ProductCode.Equals(_product.ProductCode)).ToList();
                    if (productList == null)
                    {
                        productList = new List<Product>();
                    }
                }
            }
            return productList;
        }

        public List<Product> GetsProductByName()
        {
            List<Product> productList = new List<Product>();

            using (var context = new ColorStitchDataContext())
            {
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Product> productRepository = unitOfWork.RepositoryAsync<Product>();

                    productList = productRepository.Queryable().Where(p => p.ProductName.Contains(_product.ProductName)).ToList();
                    if (productList == null)
                    {
                        productList = new List<Product>();
                    }
                }
            }
            return productList;
        }

        public List<Product> GetsAlreadyExistProductCode(string productCode)
        {
            List<Product> productList = new List<Product>();

            using (var context = new ColorStitchDataContext())
            {
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Product> productRepository = unitOfWork.RepositoryAsync<Product>();

                    productList = productRepository.Queryable().Where(p => p.ProductCode.ToLower() == productCode.ToLower()).ToList();
                    if (productList == null)
                    {
                        productList = new List<Product>();
                    }
                }
            }
            return productList;
        }
    }
}
