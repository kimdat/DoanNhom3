using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Models.Career
{ 
    public class CareerModel
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PassWord { get; set; }
        [Compare("PassWord")]
        public string ConfirmPassWord { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Resume { get; set; }
        public string Photo { get; set; }
        public string  Phone { get; set; }
        public string FullName { get; set; }

        public ICollection<EducationDetails> educationDetails { get; set; }
    }
}
