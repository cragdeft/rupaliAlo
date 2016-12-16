using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Services.Interfaces
{
    public interface IProductGetService<T>
    {
        List<T> GetsData();
        T GetProductByProductId();
        List<T> GetsProductByCode();
        List<T> GetsProductByName();
        List<T> GetsAlreadyExistProductCode(string productCode);
    }
}
