using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FileUpload.Models;
using FileUpload.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateEmployee(EmployeeCreateViewModel ecvm) {
            if (ModelState.IsValid) {
                Console.WriteLine("valid");

                string uniqueFileName = null;
                if (ecvm.Photo != null) {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath + "/images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + ecvm.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder,uniqueFileName);

                    ecvm.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                // copy createviewmodel to the actual employee model
                // code

                ViewBag.empname = ecvm.Name;
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
