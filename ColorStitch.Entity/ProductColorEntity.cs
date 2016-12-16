using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Entity
{
    public class ProductColorEntity
    {
        public int ProductColorId { get; set; }
        public string ColorCode { get; set; }

        public string ColorName { get; set; }

        public int ProductQuantity { get; set; }

        public string ProductName { get; set; }
        public string ProductId { get; set; }
    }
}
