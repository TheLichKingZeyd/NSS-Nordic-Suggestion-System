using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Repositories;
using System.Data;
using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Models;
using NordicDoorSuggestionSystem.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using NordicDoorSuggestionSystem.Models.Account;
using Microsoft.AspNetCore.Http;
using NordicDoorSuggestionSystem.Extensions;
using System.Drawing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoorSuggestionSystem.Controllers
{
    public class ProfilePageController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;
        private readonly IEmployeeRepository _employeeRepository;

        public ProfilePageController(UserManager<User> userManager, DataContext context, IEmployeeRepository employeeRepository)
        {
            _userManager = userManager;
            _context = context;
            _employeeRepository = employeeRepository;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            ProfileViewModel vm = new ProfileViewModel();
            if (currentUser == null)
            {
                return NotFound();
            }
            var employee = _employeeRepository.GetEmployeeByNumber(currentUser.EmployeeNumber);
            var employeePicture = ByteArrayToImage(employee.ProfilePicture);
            vm.EmployeeNumber = currentUser.EmployeeNumber;
            vm.FirstName = currentUser.FirstName;
            vm.LastName = currentUser.LastName;
            vm.Role = currentUser.Role;
            vm.TeamID = employee.TeamID;
            var teamname = _context.Team.Where(e => e.TeamID.Equals(employee.TeamID)).Select(e => e.TeamName).FirstOrDefault();
            vm.TeamName = teamname;
            vm.SuggestionCount = employee.SuggestionCount;
            vm.ProfilePicture = employee.ProfilePicture; 
            return View(vm);
        }

        public Image ByteArrayToImage(byte[] profilePictureToRead)
        {
            MemoryStream ms = new MemoryStream(profilePictureToRead);
            Image profilePictureOut = Image.FromStream(ms);
            return profilePictureOut;
        }

        // GET: /<controller>/
        public IActionResult Statistic()
        {
            return View();
        }



        //byte[] picture ???
        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(ProfileViewModel profilevm)
        {
            //byte[] ImageToByteArray(System.Drawing.Image imageIn)
            //{
            //    using (var ms = new MemoryStream())
            //    {
            //        imageIn.Save(ms, imageIn.RawFormat);
            //        return ms.ToArray();
            //    }
            //}

            //var Imgtemp = new byte[16777215];
            //Imgtemp[16777215] = ImageToByteArray(profilevm.ProfilePicture);

            //foreach (var file in ICollection<IFormFIle> ProfilePicture)
            //{
            //    if (file.Length > 0)
            //    {
            //        using (var ms = new MemoryStream())
            //        {
            //            file.CopyTo(ms);
            //            var fileBytes = ms.ToArray();
            //            //string s = Convert.ToBase64String(fileBytes);
            //            // act on the Base64 data
            //        }
            //    }
            //}

            var formFile = FormFileExtensions.GetBytes(profilevm.NewProfilePicture);


            var employee = new Employee
            {
                EmployeeNumber = profilevm.EmployeeNumber,
                FirstName = profilevm.FirstName,
                LastName = profilevm.LastName,
                Role = profilevm.Role,
                TeamID = profilevm.TeamID,
                ProfilePicture = formFile,
                SuggestionCount = profilevm.SuggestionCount,
            };
            _employeeRepository.Update(employee);

            return RedirectToAction("Index");
        }
    }
}

