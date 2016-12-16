using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorStitch.Model.Model;
using ColorStitch.Model.ModelDataContext;
using ColorStitch.Services.Interfaces;
using Repository.Pattern.Ef6;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace ColorStitch.Services.ProductColorService
{
    
    public class ProductColorDeleteService : IDeleteService<ProductColor>
    {
        public ProductColor _productColor { get; set; }
        public ProductColorDeleteService(ProductColor productColor)
        {
            _productColor = productColor;
        }
        public ProductColor Removed()
        {
            ProductColor oProduct = new ProductColor();
            oProduct = new ProductColorGetService(_productColor).GetColorByColorId();
            if (oProduct.ProductColorId > 0)
            {
                using (var context = new ColorStitchDataContext())
                {


                    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                    {
                        IRepositoryAsync<ProductColor> productRepository = new Repository<ProductColor>(context, unitOfWork);
                        productRepository.Delete(oProduct);
                        unitOfWork.SaveChanges();
                    }
                }
            }
            return oProduct;
        }
    }
}
