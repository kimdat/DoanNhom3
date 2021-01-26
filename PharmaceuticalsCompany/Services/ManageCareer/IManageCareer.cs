using PharmaceuticalsCompany.Models.Career;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsCompany.Services.ManageCareer
{
    public interface IManageCareer
    {
        Task<ApplicationUser> GetUser(string iD);
    }
}
