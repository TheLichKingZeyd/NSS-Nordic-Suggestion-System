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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoorSuggestionSystem.Controllers
{
    public class ProfilePageController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;

        public ProfilePageController(UserManager<User> userManager, DataContext context)
        {
            _userManager = userManager;
            _context = context;
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
            vm.EmployeeNumber = currentUser.EmployeeNumber;
            vm.FirstName = currentUser.FirstName;
            vm.LastName = currentUser.LastName;
            vm.Role = currentUser.Role;
            var mittTeam = _context.Employees.Where(e => e.EmployeeNumber.Equals(vm.EmployeeNumber)).Select(e => e.TeamID).FirstOrDefault();
            vm.TeamID = mittTeam;
            var teamname = _context.Team.Where(e => e.TeamID.Equals(vm.TeamID)).Select(e => e.TeamName).FirstOrDefault();
            vm.TeamName = teamname;
            var created = _context.Employees.Where(e => e.EmployeeNumber.Equals(vm.EmployeeNumber)).Select(e => e.CreatedSuggestions).FirstOrDefault();
            vm.CreatedSuggestions = created;
            var completed = _context.Employees.Where(e => e.EmployeeNumber.Equals(vm.EmployeeNumber)).Select(e => e.CompletedSuggestions).FirstOrDefault();
            vm.CompletedSuggestions = completed;
            return View(vm);
        }

        // GET: /<controller>/
        public IActionResult Statistic()
        {
            return View();
        }
    }
}

