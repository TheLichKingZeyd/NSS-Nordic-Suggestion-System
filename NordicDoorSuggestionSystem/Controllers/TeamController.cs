using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Models;
using Microsoft.AspNetCore.Identity;
using NordicDoorSuggestionSystem.Repositories;
using System.Data;

namespace NordicDoorSuggestionSystem.Controllers
{
    //[Authorize]
    public class TeamController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly ISuggestionRepository _suggestionRepository;
        private readonly DataContext _context;
        private readonly ISqlConnector sqlConnector;
        private readonly ITeamRepository _teamRepository;

        public TeamController(UserManager<User> userManager, ISuggestionRepository suggestionRepository, DataContext context, ISqlConnector sqlConnector, ITeamRepository teamRepository)


        {
            _userManager = userManager;
            _suggestionRepository = suggestionRepository;
            _context = context;
            this.sqlConnector = sqlConnector;
            _teamRepository = teamRepository;
        }

        [Authorize(Roles = "Administrator,Team Leder,Standard Bruker")]
        public IActionResult Index()
        {
            var teams = _context.Team;
            return View(teams);
        }

        [Authorize(Roles = "Administrator,Team Leder,Standard Bruker")]
        public IActionResult MyTeam()
        {
            return View();
        }

        [Authorize(Roles = "Administrator,Team Leder,Standard Bruker")]
        public async Task<IActionResult> MyTeam(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User); 
            var myTeam = _context.Employees.Where(d => d.TeamID.Equals(user.EmployeeNumber));
            return View(myTeam);
        }
        /* public async Task<IActionResult> DetailsMembers(int id)
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
        } */
    }
}