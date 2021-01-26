using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PharmaceuticalsCompany.Models.Career;
using PharmaceuticalsCompany.Data;
using Microsoft.AspNetCore.Identity;

namespace PharmaceuticalsCompany.Controllers.Career
{
    public class EducationController : Controller
    {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _um;
        private readonly SignInManager<ApplicationUser> _sm;


        public EducationController(ApplicationDbContext context, UserManager<ApplicationUser> um, SignInManager<ApplicationUser> sm)
        {

            _um = um;
            _sm = sm;
            this.context = context;

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}/*

        [HttpPost]
        
        [HttpPost]
        public async Task<IActionResult> Edit(string Id, ICollection<EducationCareer> educationCareers)
        {
        
          
              var oldEducationCareer = context.EducationCareers.Where(e => e.User_Id.Equals("05c36550-cac8-4a0d-8a0d-5e9a447475e9")).ToList();
          foreach (var  item in oldEducationCareer)
          {
              context.EducationCareers.Remove(item);
              context.SaveChanges();
          }

          int  order = 1;
          foreach (var educationCareer in educationCareers)
          {
              var findEducation = context.Educations.Where(e => e.Name_school.Equals("dat")).FirstOrDefault();
                //   && e.Location.Equals(educationCareer.Education.Location));
            //  var updateEducationCareer = context.EducationCareers.Where(e=>e.Education_Id.Equals(educationCareer.Education_Id)).SingleOrDefault();
              if (findEducation == null)
              {
                  var new_education = new Education
                  {
                      Name_school = educationCareer.Education.Name_school,
                      Location = educationCareer.Education.Location
                  };
                  context.Educations.Add(new_education);
                  context.SaveChanges();

                //  updateEducationCareer.Education_Id = new_education.Id;
              }
              else
              {
                //  updateEducationCareer.Education_Id = findEducation.Id;
              }
            //  context.EducationCareers.Remove(updateEducationCareer);

              //updateEducationCareer.JoinDate = educationCareer.JoinDate;
             // updateEducationCareer.EndDate = educationCareer.EndDate;
              educationCareer.User_Id = "05c36550-cac8-4a0d-8a0d-5e9a447475e9";
              educationCareer.Order = order;
              order++;
              context.EducationCareers.Add(educationCareer);
              context.SaveChanges();
          }
          

            return View(); }
         */



