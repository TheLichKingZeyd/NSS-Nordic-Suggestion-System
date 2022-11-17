using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Repositories;
using System.Data;

namespace bacit_dotnet.MVC.Controllers
{
    //[Authorize(Roles ="Administrator")]
    public class AdministrationController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmployeeRepository employeeRepository;

        public AdministrationController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IEmployeeRepository employeeRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public async Task<IActionResult> DeleteUser (string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var currentUser = _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return View("Denne brukeren eksisterer ikke");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    employeeRepository.Delete(user.EmployeeNumber);
                    return RedirectToAction("Users");
                } 
                else 
                {
                    return RedirectToAction("Users");
                }
            }
        }
    }
}
