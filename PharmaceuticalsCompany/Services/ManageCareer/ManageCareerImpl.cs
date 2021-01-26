using Microsoft.AspNetCore.Identity;
using PharmaceuticalsCompany.Data;
using PharmaceuticalsCompany.Models.Career;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Services.ManageCareer
{
    public class ManageCareerImpl : IManageCareer
    {
     
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _um;

        public ManageCareerImpl(ApplicationDbContext context, UserManager<ApplicationUser> um)
        {
           
            this.context = context;
            _um = um;

        }

        public  IEnumerable<ApplicationUser> GetAllUser()
        {
           

            return _um.Users;

        }

        public  ApplicationUser GetUser(string id)
        {

            ApplicationUser user = _um.FindByIdAsync(id).Result;
            return user;
        }

        public IEnumerable<EducationDetails> getEducation(string id)
        {
      
            return context.EducationDetails.Where(e => e.User_id == id).ToList();
        }

        /*
public async Task<CareerModel> GetUser(string id)
{

   ApplicationUser user = _um.FindByIdAsync(id).Result;
   if (user != null)
       return  user;

   else
       return null;
}*/
    }
}
