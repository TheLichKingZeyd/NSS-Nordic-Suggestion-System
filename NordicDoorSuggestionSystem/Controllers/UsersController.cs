using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Models.Users;
using NordicDoorSuggestionSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NordicDoorSuggestionSystem.Controllers
{
    // [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Index(string? email)
        {
            var model = new UserViewModel();
            model.Users = userRepository.GetUsers();
            if (email != null)
            {
                var currentUser = model.Users.FirstOrDefault(x => x.Email == email);
                if (currentUser != null)
                {
                    model.EmployeeNumber = currentUser.EmployeeNumber;
                    model.Email = currentUser.Email;
                    model.Name = currentUser.Name;
                    model.Role = currentUser.Role;
                    model.Team = currentUser.Team;
                    model.IsAdmin = userRepository.IsAdmin(currentUser.Email);
                    // model.IsTeamLead = userRepository.IsTeamLead(currentUser.Email);
                    // model.IsEmployee = userRepository.IsEmployee(currentUser.Email);
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Save(UserViewModel model)
        {

            UserEntity newUser = new UserEntity
            {
                Name = model.Name,
                Email = model.Email,
                EmployeeNumber = model.EmployeeNumber,
                Role = model.Role,
                Team = model.Team,
            };
            var roles = new List<string>();
             if (model.IsAdmin)
                roles.Add("Administrator");
            userRepository.Update(newUser, roles);

            /* if (model.IsTeamLead)
                roles.Add("Teamleder");
            userRepository.Update(newUser, roles);

            if (model.IsEmployee)
                roles.Add("Employee");
            userRepository.Update(newUser, roles); */
            
             return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(string email)
        {
            userRepository.Delete(email);
            return RedirectToAction("Index");
        }
    }
}
