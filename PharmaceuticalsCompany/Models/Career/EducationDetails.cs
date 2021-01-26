using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Models.Career
{
    public class EducationDetails
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Id { get; set; }
        public string  Name_school { get; set; }
        public string Location { get; set; }

        public DateTime JoinDate { get; set; }

        public DateTime EndDate { get; set; }
        public ApplicationUser User { get; set; }
        public string User_id { get; set; }


    }
}
