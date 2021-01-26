using PharmaceuticalsCompany.Models.Career;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Services.ManageCareer
{
    public interface IManageCareer
    {
        IEnumerable<ApplicationUser> GetAllUser();
        ApplicationUser GetUser(string id);
        IEnumerable<EducationDetails> getEducation(string id);
    } 
}
