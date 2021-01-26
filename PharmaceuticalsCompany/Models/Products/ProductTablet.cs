using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Models.Products
{
    public class ProductTablet
    {
        [Key]
        public int TabId { get; set; }
        [Required]
        public string TabName { get; set; }
        [Required]
        public int Model_Number { get; set; }
        public string Dies { get; set; }
        public float MaxPressure { get; set; }
        public float MaxDiameter { get; set; }
        public float MaxDept { get; set; }
        public string ProductCapacity { get; set; }
        public float MachineSize { get; set; }
        public float NetWeight { get; set; }
        public string TabPhoto { get; set; }
    }
}
