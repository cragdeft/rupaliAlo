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
    public class Product : Entity
    {
        public Product()
        {
            ProductPrice = 0;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}
