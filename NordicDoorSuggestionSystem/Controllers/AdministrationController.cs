using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Repositories;
using System.Data;
using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Models;
using NordicDoorSuggestionSystem.Models.Administrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using NordicDoorSuggestionSystem.Models.Account;

namespace bacit_dotnet.MVC.Controllers
{
    //[Authorize(Roles ="Administrator")]
    public class AdministrationController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ITeamRepository _teamRepository;

        private readonly DataContext _context;

        public AdministrationController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IEmployeeRepository employeeRepository, DataContext context, ITeamRepository teamRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.employeeRepository = employeeRepository;
            _context = context;
            _teamRepository = teamRepository;
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

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem()
            {
                Value = "Standard Bruker",
                Text = "Standard Bruker"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Team Leder",
                Text = "Team Leder"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Administrator",
                Text = "Administrator"
            });
            var userRoles = await _userManager.GetRolesAsync(user);
            var toEdit = new UserEditViewModel
            {
                Id = user.Id,
                EmployeeNumber = user.EmployeeNumber.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleList = listItems,
                PreviousRole = userRoles.ElementAt(0),
            };
            return View(toEdit);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserEditViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                Employee employee = new Employee
                {
                    EmployeeNumber = user.EmployeeNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };
                employeeRepository.Update(employee);
                await _userManager.AddToRoleAsync(user, model.RoleSelected);
                await _userManager.RemoveFromRoleAsync(user, model.PreviousRole);
                return RedirectToAction("Users");
            } 
            
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
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

        [HttpGet]
        public IActionResult Teams()
        {
            var teams = _context.Team;
            return View(teams);
        }

        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeam([Bind("TeamName, TeamLeader, DepartmentID")] TeamViewModel teamViewModel)
        {

            if (ModelState.IsValid)
            {
                var newTeam = new Team {
                    TeamName = teamViewModel.TeamName,
                    TeamLeader = teamViewModel.TeamLeader,
                    DepartmentID = teamViewModel.DepartmentID
                    
                };

                _context.Add(newTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Teams));
            }
            return View();
        }

        public async Task<IActionResult> DeleteTeam(int? id)
        {
            if (id == null || await _teamRepository.GetTeams() == null)
            {
                return NotFound();
            }

            var team = await _teamRepository.GetTeam(id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }


        [HttpPost, ActionName("DeleteTeam")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTeamConfirmed(int id)
        {
            if (await _teamRepository.GetTeams() == null)
            {
                return Problem("Entity set 'DataContext.Teams'  is null.");
            }
            var team = await _teamRepository.GetTeam(id);
            if (team != null)
            {
                await _teamRepository.DeleteTeam(team);
                await _teamRepository.SaveChanges();

            }

            return RedirectToAction(nameof(Teams));
        }


        public async Task<IActionResult> EditTeam(int? id)
        {
            if (id == null || await _teamRepository.GetTeams() == null)
            {
                return NotFound();
            }

            var team = await _teamRepository.GetTeam(id);
            if (team == null)
            {
                return NotFound();
            }

            var editTeamViewModel = new TeamViewModel {
                    TeamID = team.TeamID,
                    TeamName = team.TeamName,
                    TeamLeader = team.TeamLeader,
                    DepartmentID = team.DepartmentID
            };

            return View(editTeamViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTeam(int id, [Bind("TeamName, TeamLeader")] TeamViewModel editTeamViewModel)
        {
            var team = await _teamRepository.GetTeam(id);
            if ( team == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    team.TeamName = editTeamViewModel.TeamName;
                    team.TeamLeader = editTeamViewModel.TeamLeader;

                    await _teamRepository.Update(team);
                    await _teamRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Teams));
            }
            return View();
        }

        public IActionResult TeamMembers()
        {
            return View();
        }
    }
}
