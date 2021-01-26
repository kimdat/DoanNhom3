using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Models.Products
{
    public class ProductLiquidFilling
    {
        [Key]
        public int LFId { get; set; }
        [Required]
        public string LFName { get; set; }
        public string AirPressure { get; set; }
        public float Air_Volume { get; set; }
        public string FillingSpeed { get; set; }
        public float FillingRange { get; set; }
        public string AriPhoto { get; set; }
    }
}
