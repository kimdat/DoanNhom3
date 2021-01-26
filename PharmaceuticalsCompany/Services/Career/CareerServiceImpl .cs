using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PharmaceuticalsCompany.Models.Career;
using PharmaceuticalsCompany.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace PharmaceuticalsCompany.Services.Career
{
    public class CareerServiceImpl : ICareerService
    {
        private readonly UserManager<ApplicationUser> _um;
        private readonly SignInManager<ApplicationUser> _sm;
        private ApplicationDbContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CareerServiceImpl(UserManager<ApplicationUser> um, SignInManager<ApplicationUser> sm,ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _um = um;
            _sm = sm;
            this.context = context;
            _httpContextAccessor = httpContextAccessor;

        }

        public  async Task<CareerModel> GetUser()
        {
            var userid =  _um.GetUserId(_httpContextAccessor.HttpContext.User);
            ApplicationUser user =  _um.FindByIdAsync(userid).Result;
            if (user != null)
            {
                CareerModel career = new CareerModel();
                career.Id = userid;
                career.Email = user.Email;
                career.Address = user.Address;
                career.Phone = user.PhoneNumber;
                career.DateOfBirth = user.DateOfBirth;
                   career.Gender = user.Gender;
                career.Photo = user.Photo;
                career.Resume = user.Resume;
                career.FullName = user.FullName;
                return  career;
            }
            else
                return null;
                 
        }

        public async Task<CareerModel> Login(CareerModel career)
        {
                var result = await _sm.PasswordSignInAsync(career.Email, career.PassWord, false, false);
                if(result.Succeeded)
                {
                    return career;
                }
                else
                {
                    return null;
                }
        }

        public async Task<CareerModel> Logout()
        {
            await _sm.SignOutAsync();
            return null;
        }

        /*
        public  async Task<CareerModel> Register(CareerModel model, ICollection<EducationCareer> educationCareers)
        {
         
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                DateOfBirth=model.DateOfBirth,
               Gender=model.Gender,
                Resume=model.Resume,
                Address=model.Address,
                Photo=model.Photo,
                PhoneNumber=model.Phone,
                FullName=model.FullName
            };
            var result = await _um.CreateAsync(user, model.PassWord);
            int  order = 1;
            foreach (var educationCareer in educationCareers)
            {
                var findEducation = context.Educations.FirstOrDefault(e => e.Name_school.ToLower().Equals(educationCareer.Education.Name_school.ToLower())
                     && e.Location.ToLower().Equals(educationCareer.Education.Location.ToLower()));
                if (findEducation == null)
                {
                    var new_education = new Education
                    {
                        Name_school = educationCareer.Education.Name_school,
                        Location = educationCareer.Education.Location
                    };
                    context.Educations.Add(new_education);
                  //  context.SaveChanges();
                    educationCareer.Education_Id = new_education.Id;
                }
                else
                {
                    educationCareer.Education_Id = findEducation.Id;
                }
                educationCareer.Order = order;
                order++;
                educationCareer.User_Id = user.Id;
                context.EducationCareers.Add(educationCareer);
                context.SaveChanges();
            }


            if (result.Succeeded)
             {

                   await _sm.SignInAsync(user, isPersistent: false);
                   return model;
            }
            else
            {
                return null;
            }
             



        }*/
        public async Task<CareerModel> EditResume(CareerModel career)
        {
            var user = await _um.FindByIdAsync(career.Id);

            user.Resume = career.Resume;


            var result = await _um.UpdateAsync(user);
            if (result.Succeeded)
            {


                return career;
            }
            else
            {
                return null;
            }

        }

        public async Task<CareerModel> EditProfile(CareerModel career)
        {
              var user = await _um.FindByIdAsync(career.Id);

              user.Address = career.Address;
                user.DateOfBirth = career.DateOfBirth;
               user.Gender = career.Gender;
                user.PhoneNumber = career.Phone;
                user.Photo = career.Photo;
                user.FullName = career.FullName;
            
          
            var result = await _um.UpdateAsync(user);
            if (result.Succeeded)
            {

               
                return career;
            }
            else
            {
                return null;
            }

        }

        public async Task<CareerModel> Register(CareerModel career, ICollection<EducationDetails> educationDetails)
        {
            var user = new ApplicationUser
            {
                UserName = career.Email,
                Email = career.Email,
                DateOfBirth = career.DateOfBirth,
                Gender = career.Gender,
                Resume = career.Resume,
                Address = career.Address,
                Photo = career.Photo,
                PhoneNumber = career.Phone,
                FullName = career.FullName
            };
            var result = await _um.CreateAsync(user, career.PassWord);
         
            foreach (var educationDetail in educationDetails)
            {
                
              
                educationDetail.User_id = user.Id;
                context.EducationDetails.Add(educationDetail);
                context.SaveChanges();
            }


            if (result.Succeeded)
            {

                await _sm.SignInAsync(user, isPersistent: false);
                return career;
            }
            else
            {
                return null;
            }
        }

      

        public async Task<IEnumerable<EducationDetails>> GetEducationDetails()
        {
            var userid = _um.GetUserId(_httpContextAccessor.HttpContext.User);
            return await context.EducationDetails.Where(e=>e.User_id==userid).ToListAsync();
        }

        public async Task<bool> EditEducationDetails(IEnumerable<EducationDetails> educationDetails)
        {
            var user_id = _um.GetUserId(_httpContextAccessor.HttpContext.User);
            var list = context.EducationDetails.Where(e => e.User_id == user_id);
            foreach (var item in  list)
            {
                context.EducationDetails.Remove(item);
            }
            
            foreach (var NewEducationDetail in educationDetails)
            {
               /* var educationDetail = context.EducationDetails.Find(NewEducationDetail.Id);
                if(educationDetail!=null)
                {
                    educationDetail.Name_school = NewEducationDetail.Name_school;
                    educationDetail.Location = NewEducationDetail.Location;
                    educationDetail.JoinDate = NewEducationDetail.JoinDate;
                    educationDetail.EndDate = NewEducationDetail.EndDate;

                }*/
                NewEducationDetail.User_id = user_id;
                context.EducationDetails.Add(NewEducationDetail);
             
              
            }
            context.SaveChanges();
            return true;
        }

        public async Task<bool> ChangePassWord(ChangePassWordViewModel model)
        {
            var user = await _um.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null)
                return false;
            var result = await _um.ChangePasswordAsync(user, model.CurrentPassWord, model.NewPassWord);
            if (result.Succeeded)
                return true;

            else
                return false;
        }

       
        /*
public async Task<List<EducationCareer>> GetEducationUser()

{
var userid = _um.GetUserId(_httpContextAccessor.HttpContext.User);
ApplicationUser user = _um.FindByIdAsync(userid).Result;
var list = (from p in context.EducationCareers
join e in context.Educations
on p.Education_Id equals e.Id
where p.User_Id.Equals(user.Id)
select new EducationCareer
{
Education = e ,
JoinDate = p.JoinDate,
EndDate = p.EndDate,
Education_Id = p.Education_Id,
Order = p.Order
}).OrderBy(e => e.Order);

return  list.ToList();


}

public async Task<bool> EditEducation(IEnumerable<EducationCareer> educationCareers, string Id)
{
// var user = await _um.FindByIdAsync(Id);
ApplicationUser career = context.Careers.Include(e => e.EducationCareers).Single(c => c.Id ==Id);
int order=1;

foreach (var educationCareer in educationCareers)
{

var findEducation = context.Educations.FirstOrDefault(e => e.Name_school.ToLower().Equals(educationCareer.Education.Name_school.ToLower())
&& e.Location.ToLower().Equals(educationCareer.Education.Location.ToLower()));
/*
var oldEducationCareer = context.EducationCareers.Where(e => e.User_Id.Equals("05c36550-cac8-4a0d-8a0d-5e9a447475e9")).ToList();
foreach (var item in oldEducationCareer)
{
context.EducationCareers.Remove(item);
context.SaveChanges();

}

var oldEducation = context.Educations.Find(educationCareer.Education_Id);
var oldEducationcareer=career.EducationCareers.FirstOrDefault(e => e.Education== oldEducation) ;
career.EducationCareers.Remove(oldEducationcareer);

var newEducationCareers = new EducationCareer();

//  var updateEducationCareer = context.EducationCareers.Where(e => e.Education_Id.Equals(educationCareer.Education_Id) && e.User_Id.Equals(Id)).SingleOrDefault();
if (findEducation == null)
{


var new_education = new Education
{
Name_school = educationCareer.Education.Name_school,
Location = educationCareer.Education.Location
};
context.Educations.Add(new_education);
newEducationCareers.Education = new_education;
//  context.Educations.Add(new_education);
//  context.EducationCareers.Remove(updateEducationCareer);
///   educationCareer.User_Id = user.Id;
//  educationCareer.Order = order;

//   context.EducationCareers.Add(educationCareer);


}
else
{
newEducationCareers.Education = findEducation;
//  updateEducationCareer.Education_Id = findEducation.Id;

//  user1.EducationCareers.Add(educationCareer);


}
newEducationCareers.User = career;
newEducationCareers.JoinDate = educationCareer.JoinDate;
newEducationCareers.EndDate = educationCareer.EndDate;
newEducationCareers.Order = order;
career.EducationCareers.Add(newEducationCareers);
order++;

context.SaveChanges();

}
return true;
} */
    }
}
