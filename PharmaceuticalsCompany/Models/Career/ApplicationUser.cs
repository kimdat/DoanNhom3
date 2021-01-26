using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Models.Career
{
    public class ApplicationUser : IdentityUser
    {

        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Resume { get; set; }
        public string Photo { get; set; }
        public  string FullName { get; set; }
        public ICollection<EducationDetails>educationDetails { get; set; }

    }
}
