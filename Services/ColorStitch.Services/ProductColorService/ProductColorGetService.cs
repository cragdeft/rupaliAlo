using AutoMapper;
using ColorStitch.Entity;
using ColorStitch.Model.Model;
using ColorStitch.Model.ModelDataContext;
using ColorStitch.Services.Interfaces;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Services.ProductColorService
{

  public class ProductColorGetService : IProductColorGetService<ProductColor>
  {
    public ProductColor _productColor { get; set; }
    public ProductColorGetService(ProductColor productColor)
    {
      _productColor = productColor;
    }

    public ProductColor GetColorByColorId()
    {
      ProductColor oProductColor = new ProductColor();

      using (var context = new ColorStitchDataContext())
      {
        using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
        {
          IRepositoryAsync<ProductColor> productRepository = new Repository<ProductColor>(context, unitOfWork);

          oProductColor = productRepository.Queryable().Where(p => p.ProductColorId == _productColor.ProductColorId).Include(x=>x.Product).FirstOrDefault();
          if (oProductColor == null)
          {
            oProductColor = new ProductColor();
          }
        }
      }
      return oProductColor;
    }

    public List<ProductColorEntity> GetsColorEntityData()
    {
      List<ProductColorEntity> productColorEntityList = new List<ProductColorEntity>();

      using (var context = new ColorStitchDataContext())
      {
        using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
        {
          IRepositoryAsync<ProductColor> productRepository = new Repository<ProductColor>(context, unitOfWork);

          productColorEntityList = FillColorEntity(productRepository.Queryable().Include(x => x.Product).ToList());
          if (productColorEntityList == null)
          {
            productColorEntityList = new List<ProductColorEntity>();
          }
        }
      }
      return productColorEntityList;
    }

    public List<ProductColorEntity> FillColorEntity(List<ProductColor> list)
    {
      Mapper.CreateMap<ProductColor, ProductColorEntity>()
        .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.ProductId));
            List<ProductColorEntity> oUserInfoEntity = Mapper.Map<List<ProductColor>, List<ProductColorEntity>>(list);
      return oUserInfoEntity;
    }

    public List<ProductColor> GetsColorByColorName()
    {
      List<ProductColor> productList = new List<ProductColor>();

      using (var context = new ColorStitchDataContext())
      {
        using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
        {
          IRepositoryAsync<ProductColor> productRepository = unitOfWork.RepositoryAsync<ProductColor>();

          productList = productRepository.Queryable().Where(p => p.ColorName.ToLower().Contains(_productColor.ColorName.ToLower())).Include(x=>x.Product).ToList();
          if (productList == null)
          {
            productList = new List<ProductColor>();
          }
        }
      }
      return productList;
    }

    public List<ProductColor> GetsData()
    {
      List<ProductColor> productColorList = new List<ProductColor>();

      using (var context = new ColorStitchDataContext())
      {
        using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
        {
          IRepositoryAsync<ProductColor> productRepository = new Repository<ProductColor>(context, unitOfWork);

          productColorList = productRepository.Queryable().Include(x => x.Product).ToList();
          if (productColorList == null)
          {
            productColorList = new List<ProductColor>();
          }
        }
      }
      return productColorList;
    }


  }


}
