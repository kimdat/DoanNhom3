
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
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.OfficeChart;
using Syncfusion.Pdf;
using Spire.Xls;

using Aspose.Slides;

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
                return RedirectToAction("Authentication");
            else

            {
                var model = await services.GetUser();
               

                ViewBag.Education = await services.GetEducationDetails();
              
               // ViewBag.Msg = a;
                return View(model);
            }
            
        }
        public IActionResult Authentication()
        {
            if (!User.Identity.IsAuthenticated)
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


            string filePath = "";

            if (file != null && file.Length > 0)
            {

                filePath = $"{_hostingEnvironment.WebRootPath}\\files\\{file.FileName}";

                using (FileStream fileStream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    career.Resume = file.FileName;
                    fileStream.Close();
                }

                if (career.Resume.Split(".").Last() == "docx" || career.Resume.Split(".").Last() == "doc" || career.Resume.Split(".").Last() == "docm" || career.Resume.Split(".").Last() == "dot" || career.Resume.Split(".").Last() == "dotx")
                {
                    FileStream docStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    //Loads file stream into Word document

                    WordDocument wordDocument = new WordDocument(docStream, Syncfusion.DocIO.FormatType.Automatic);
                    //Instantiation of DocIORenderer for Word to PDF conversion
                    DocIORenderer render = new DocIORenderer();
                    //Sets Chart rendering Options.
                    render.Settings.ChartRenderingOptions.ImageFormat = ExportImageFormat.Jpeg;
                    //Converts Word document into PDF document
                    PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);
                    //Releases all resources used by the Word document and DocIO Renderer objects
                    render.Dispose();
                    wordDocument.Dispose();
                    docStream.Close();
                    System.IO.File.Delete(filePath);

                    //Saves the PDF file
                    // MemoryStream outputStream = new MemoryStream();
                    // pdfDocument.Save(outputStream);
                    //Closes the instance of PDF document object
                    //   pdfDocument.Close();

                    string newfile = "";
                    string extentionFile = file.FileName.Split(".").Last();
                    int indexextensionFile = file.FileName.LastIndexOf(extentionFile);
                    newfile = file.FileName.Substring(0, indexextensionFile);
                    newfile = newfile + "pdf";
                    string newfilePath = $"{_hostingEnvironment.WebRootPath}\\files\\{newfile}";
                    using (var fs = new FileStream(newfilePath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Flush();
                        pdfDocument.Save(fs);
                        career.Resume = newfile;
                    }

                }
                else if (career.Resume.Split(".").Last() == "ppt" || career.Resume.Split(".").Last() == "pptx" || career.Resume.Split(".").Last() == "pptm")
                {
                    Presentation presentation = new Presentation(filePath);

                    System.IO.File.Delete(filePath);

                    string newfile = "";
                    string extentionFile = file.FileName.Split(".").Last();
                    int indexextensionFile = file.FileName.LastIndexOf(extentionFile);
                    newfile = file.FileName.Substring(0, indexextensionFile);
                    newfile = newfile + "pdf";
                    string newfilePath = $"{_hostingEnvironment.WebRootPath}\\files\\{newfile}";
                    presentation.Save(newfilePath, Aspose.Slides.Export.SaveFormat.Pdf);
                    career.Resume = newfile;
                }

                else
                {
                    Workbook workbook = new Workbook();
                    workbook.LoadFromFile(filePath);
                    System.IO.File.Delete(filePath);

                    string newfile = "";
                    string extentionFile = file.FileName.Split(".").Last();
                    int indexextensionFile = file.FileName.LastIndexOf(extentionFile);
                    newfile = file.FileName.Substring(0, indexextensionFile);
                    newfile = newfile + "pdf";
                    string newfileath = $"{_hostingEnvironment.WebRootPath}\\files\\{newfile}";
                    Worksheet sheet = workbook.Worksheets[0];
                    sheet.SaveToPdf(newfileath);
                    career.Resume = newfile;

                }

            }
            if (fileUser.Length > 0)
            {
                string filePathUser = Path.Combine("wwwroot/images", fileUser.FileName);
               
               
                if (!System.IO.File.Exists(filePathUser))
                {
                   var stream = new FileStream(filePathUser, FileMode.Create);
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
           
            string filePath= "";

            if (file != null && file.Length > 0)
            {
                
                filePath = $"{_hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
               
                using (FileStream fileStream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    career.Resume = file.FileName;
                    fileStream.Close();
                }

               if(career.Resume.Split(".").Last()=="docx" || career.Resume.Split(".").Last()=="doc" || career.Resume.Split(".").Last()== "docm" || career.Resume.Split(".").Last()=="dot" || career.Resume.Split(".").Last()=="dotx")
               {
                    FileStream docStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    //Loads file stream into Word document

                    WordDocument wordDocument = new WordDocument(docStream, Syncfusion.DocIO.FormatType.Automatic);
                    //Instantiation of DocIORenderer for Word to PDF conversion
                    DocIORenderer render = new DocIORenderer();
                    //Sets Chart rendering Options.
                    render.Settings.ChartRenderingOptions.ImageFormat = ExportImageFormat.Jpeg;
                    //Converts Word document into PDF document
                   PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);
                    //Releases all resources used by the Word document and DocIO Renderer objects
                    render.Dispose();
                    wordDocument.Dispose();
                    docStream.Close();
                    System.IO.File.Delete(filePath);

                    //Saves the PDF file
                    // MemoryStream outputStream = new MemoryStream();
                    // pdfDocument.Save(outputStream);
                    //Closes the instance of PDF document object
                    //   pdfDocument.Close();

                    string newfile = "";
                    string extentionFile = file.FileName.Split(".").Last();
                    int indexextensionFile = file.FileName.LastIndexOf(extentionFile);
                    newfile = file.FileName.Substring(0, indexextensionFile);
                    newfile = newfile + "pdf";
                    string newfilePath = $"{_hostingEnvironment.WebRootPath}\\files\\{newfile}";
                    using (var fs = new FileStream(newfilePath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Flush();
                        pdfDocument.Save(fs);
                        career.Resume = newfile;
                    }

               }
                else if (career.Resume.Split(".").Last() == "ppt" || career.Resume.Split(".").Last() == "pptx"||career.Resume.Split(".").Last() == "pptm")
                {
                    Presentation presentation = new Presentation(filePath);
                   
                    System.IO.File.Delete(filePath);

                    string newfile = "";
                    string extentionFile = file.FileName.Split(".").Last();
                    int indexextensionFile = file.FileName.LastIndexOf(extentionFile);
                    newfile = file.FileName.Substring(0, indexextensionFile);
                    newfile = newfile + "pdf";
                    string newfilePath = $"{_hostingEnvironment.WebRootPath}\\files\\{newfile}";
                    presentation.Save(newfilePath, Aspose.Slides.Export.SaveFormat.Pdf);
                    career.Resume = newfile;
                }

               else
                {
                    Workbook workbook = new Workbook();
                    workbook.LoadFromFile(filePath);
                    System.IO.File.Delete(filePath);

                    string newfile = "";
                    string extentionFile = file.FileName.Split(".").Last();
                    int indexextensionFile = file.FileName.LastIndexOf(extentionFile);
                    newfile = file.FileName.Substring(0, indexextensionFile);
                    newfile = newfile + "pdf";
                    string newfileath = $"{_hostingEnvironment.WebRootPath}\\files\\{newfile}";
                    Worksheet sheet = workbook.Worksheets[0];
                    sheet.SaveToPdf(newfileath);
                    career.Resume = newfile;
                   
                }

            }





            /*
            if (file!=null && file.Length > 0)
            {
                string fileName = $"{_hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                   career.Resume = file.FileName;
                }
            }*/
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
 
 
 