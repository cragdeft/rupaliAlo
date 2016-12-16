using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Model.Model
{
    public class ProductColor : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductColorId { get; set; }
        public string ColorCode { get; set; }

        public string ColorName { get; set; }

        public int ProductQuantity { get; set; }

        public virtual Product Product { get; set; }
        
        
    }
}
