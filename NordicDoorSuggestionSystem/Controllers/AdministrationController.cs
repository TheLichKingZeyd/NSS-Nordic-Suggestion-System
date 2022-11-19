using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Repositories;
using System.Data;
using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Models;
using Microsoft.EntityFrameworkCore;

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

        

        [HttpGet]
        public IActionResult EditTeamMembers()
        {
            EditTeamMemberViewModel vm = new EditTeamMemberViewModel();
            var teams = _context.Team.ToList();
            var employees = _context.Employees.ToList();
            vm.EmployeeList = employees;
            vm.TeamList = teams;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTeamMembers(DetailMemberViewModel detailMemberViewModel)
        {
            var employees = _context.Employees.ToList();
            foreach (Employee employee in employees) 
            { 
                foreach (Employee updated in detailMemberViewModel.EmployeeList)
                {
                    if (employee.EmployeeNumber == updated.EmployeeNumber && employee.TeamID != updated.TeamID)
                    {
                        employeeRepository.Update(updated);
                    }
                }
            }
            return RedirectToAction("EditTeamMembers");
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

        public async Task<IActionResult> DetailsMembers(int id)
        {
            var team = await _teamRepository.GetTeam(id);
            DetailMemberViewModel vm = new DetailMemberViewModel();
            if (team == null)
            {
                return NotFound();
            }

            vm.TeamName = team.TeamName;
            vm.TeamID = team.TeamID;

            var employees = _context.Employees.Where(d => d.TeamID.Equals(team.TeamID)).ToList();
            vm.EmployeeList = employees;

            return View(vm);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        

        
    }
}
