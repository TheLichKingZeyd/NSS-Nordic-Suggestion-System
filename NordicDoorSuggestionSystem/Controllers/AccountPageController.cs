using Microsoft.AspNetCore.Mvc;
using NordicDoorSuggestionSystem.Models;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace NordicDoorSuggestionSystem.Controllers
{
    public class AccountPageController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly IEmployeeRepository _employeeRepository;

        public AccountPageController(UserManager<User> userManager, IEmployeeRepository employeeRepository)
        {
            _userManager = userManager;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void UploadProfilePicture(FormCollection form)
        {
            var currentUser = _userManager.GetUserAsync(HttpContext.User);
            var user = _employeeRepository.GetEmployeeByNumber(currentUser.Id);
            //user.ProfilePicture = form;
            _employeeRepository.Update(user);
        }
    }
}
