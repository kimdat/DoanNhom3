using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PharmaceuticalsCompany.Models.Career;
namespace PharmaceuticalsCompany.Services.Career
{
    public interface ICareerService
    {
         Task<CareerModel> Login(CareerModel career);
        Task<CareerModel> Register(CareerModel career, ICollection<EducationDetails> educationDetails);
        Task<CareerModel> Logout();
        Task<CareerModel> GetUser();
        Task<bool> ChangePassWord(ChangePassWordViewModel model);
        Task<CareerModel> EditProfile(CareerModel career);
        Task<CareerModel> EditResume(CareerModel career);
        Task<bool> EditEducationDetails(IEnumerable<EducationDetails> educationDetails);
        Task<IEnumerable<EducationDetails>> GetEducationDetails();
        //admin
       
    }
}
