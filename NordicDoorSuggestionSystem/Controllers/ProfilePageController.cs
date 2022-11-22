using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NordicDoorSuggestionSystem.Models.Employees;
using System.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoorSuggestionSystem.Controllers
{
    public class ProfilePageController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Statistic()
        {
            return View();
        }
        
        public IActionResult UploadProfilePic()
        {
            return View();
        }
/*
        [Route ("UploadProfilePic")]
        [HttpPost]
        public IActionResult UploadProfilePic(EmployeeViewModel)
        {
            HttpPostedFileBase file = Request.Files["UploadedData"];


            return View(file);
        }
        */
    }
}

