using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmaceuticalsCompany.Services.Career;
using PharmaceuticalsCompany.Models.Career;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;

namespace PharmaceuticalsCompany.Controllers.Candidate
{
    public class CareerController : Controller
    {
        IHostingEnvironment _hostingEnvironment = null;
      
        private  ICareerService services;
        public CareerController(ICareerService services, IHostingEnvironment hostingEnvironment)
        {
            
            _hostingEnvironment = hostingEnvironment;
            this.services = services;
        }
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("authentication");
            else

            {
                var model = await services.GetUser();
          
                ViewBag.Education = await services.GetEducationDetails();
                return View(model);
            }
            
        }
        public IActionResult Authentication()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("index");
            else

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> logout()
        {
            await  services.Logout();
            return RedirectToAction("authentication");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(CareerModel candidate)
        {

                var model = await services.Login(candidate);
                if (model != null)
                {

                    ViewBag.Msg = "success";
                    return RedirectToAction("index", "Career");


                }
                else
                {
                    ViewBag.Msg = "invalid";
                }
               
            
           
            return View();

        }
        public IActionResult Register()
        {

            return View();
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> Register(CareerModel career,ICollection<EducationDetails> educationDetails, IFormFile file, IFormFile fileUser, [FromServices] IHostingEnvironment hostingEnvironment,string Gender)
        {
            if (Gender == "male")
               career.Gender = true;
            else
              career.Gender = false;


            if (file.Length > 0)
            {
                string fileName = $"{_hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                   career.Resume = file.FileName;
                }
            }
            if (fileUser.Length > 0)
            {
                string filePath = Path.Combine("wwwroot/images", fileUser.FileName);
               
               
                if (!System.IO.File.Exists(filePath))
                {
                   var stream = new FileStream(filePath, FileMode.Create);
                await fileUser.CopyToAsync(stream);

                }
               
                career.Photo = "images/" + fileUser.FileName;
            }
            var result = await services.Register(career, educationDetails);
            if (result != null)
            {

                return RedirectToAction("index", "Career");
            }
            else
            {

            }

            return View();
        }
        public IActionResult PDFViewerNewTab(string fileName)
        {
            string path = _hostingEnvironment.WebRootPath + "\\files\\" + fileName;
             return File(System.IO.File.ReadAllBytes(path), "application/pdf");
        }
        [HttpPost]
        
        public async Task<IActionResult> EditEducation(IEnumerable<EducationDetails> educationDetails)
        {
            var a = services.EditEducationDetails(educationDetails);
            if (a.Result == true)
                return RedirectToAction("index", "Career");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditResume(CareerModel career, IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {

            if (file!=null && file.Length > 0)
            {
                string fileName = $"{_hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                   career.Resume = file.FileName;
                }
            }
            var edit_carrer = await services.EditResume(career);
            if (edit_carrer != null)
            {
                return RedirectToAction("index", "Career");
            }


            return View();
        }
        public IActionResult ChangePass()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePass(ChangePassWordViewModel model)
        {
          

            var changePass = await services.ChangePassWord(model);
            if (changePass == true)
                return RedirectToAction("index", "Career");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(CareerModel career, IFormFile fileUser,string Gender)
        {
          
            if (Gender == "male")
                career.Gender = true;
            else
                career.Gender = false;
       
             if (fileUser != null &&  fileUser.Length > 0 )
              {
                  string filePath = Path.Combine("wwwroot/images", fileUser.FileName);
                   if (!System.IO.File.Exists(filePath))
                   {
                       var stream = new FileStream(filePath, FileMode.Create);
                         await fileUser.CopyToAsync(stream);

                    }

                    career.Photo = "images/" + fileUser.FileName;
             }
         
             var edit_carrer = await services.EditProfile(career);
             if (edit_carrer != null)
             {
                   return RedirectToAction("index", "Career");
              }
                 
   
           
          
          
            return View();
        }
    }
}
 
 
 