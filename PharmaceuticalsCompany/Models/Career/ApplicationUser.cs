using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Models.Career
{
    public class ApplicationUser : IdentityUser
    {

        public string Address { get; set; }
        public bool Gender { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public string Resume { get; set; }
        public string Photo { get; set; }
        public  string FullName { get; set; }
        public ICollection<EducationDetails>educationDetails { get; set; }

    }
}
