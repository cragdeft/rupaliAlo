using ColorStitch.Model.Model;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Model.ModelView
{
    public class ProductView : Entity
    {
        public ProductColor Product { get; set; }
        public ProductColor ProductColor { get; set; }

    }
}
