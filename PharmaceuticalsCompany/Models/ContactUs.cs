using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Models
{
    public class ContactUs
    {
        [Key]
        public int CId { get; set; }
        public string CName { get; set; }
        public int CPhone { get; set; }
        public string FeedBack { get; set; }
    }
}
