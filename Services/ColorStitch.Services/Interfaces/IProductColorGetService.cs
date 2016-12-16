using ColorStitch.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Services.Interfaces
{
 
  public interface IProductColorGetService<T>
  {
    List<T> GetsData();
    T GetColorByColorId();
    List<T> GetsColorByColorName();
    List<ProductColorEntity> GetsColorEntityData();
  }
}
