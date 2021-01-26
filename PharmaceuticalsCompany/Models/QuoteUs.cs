using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Models.Career
{
    public class QuoteUs
    {
     
       
            [Key]
         
            public int Id { get; set; }
            public string FullName { get; set; }
            public string CompanyName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int PostalCode { get; set; }
            public string Country { get; set; }
            public int Phone { get; set; }
            public string Comments { get; set; }

        
    }
}
