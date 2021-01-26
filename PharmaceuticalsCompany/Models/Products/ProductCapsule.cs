using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Models.Products
{
    public class ProductCapsule
    {
        [Key]
        public int CapId { get; set; }
        [Required]
        public string CapName { get; set; }
        [Required]
        public float Ouput { get; set; }
        [Required]
        public float CapSize { get; set; }
        public float Machine_Dimension { get; set; }
        public float Shipping { get; set; }
        public string photo { get; set; }
    }
}
