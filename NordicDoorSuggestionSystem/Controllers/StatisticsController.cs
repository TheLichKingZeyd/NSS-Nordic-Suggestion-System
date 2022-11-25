using Microsoft.AspNetCore.Mvc;
using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace NordicDoorSuggestionSystem.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly DataContext _context;

         public StatisticsController(DataContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator,Team Leder,Standard Bruker")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator,Team Leder,Standard Bruker")]
        public IActionResult ShowStatisticsData()
        {
            StatisticsViewModel vm = new StatisticsViewModel();
            var employeeCounts = _context.Employees.OrderByDescending(x => x.CompletedSuggestions).ToList();
            vm.EmployeeList = employeeCounts;
            
            var teamCounts = _context.Team.OrderByDescending(x => x.TeamSgstnCount).ToList();
            vm.BestTeamList = teamCounts;

            return View(vm);
        }

        [Authorize(Roles = "Administrator,Team Leder,Standard Bruker")]
        [HttpPost]
        public List<object> GetStatisticsData()
        {
            List<object> data = new List<object>();

            List<string?> labels = _context.Team.Select(p=>p.TeamName).ToList();

            data.Add(labels);

            List<int?> SuggestionCount = _context.Team.Select(p=>p.TeamSgstnCount).ToList();

            data.Add(SuggestionCount);

            return data;
        }

        [Authorize(Roles = "Administrator,Team Leder,Standard Bruker")]
        [HttpPost]
        public List<object> GetDepartmentData()
        {
            List<object> dataset = new List<object>();
            List<String?> labels = new List<string?>();
            labels.Add("Lagde forslag");
            labels.Add("Fullf�rte forslag");
            dataset.Add(labels);

            List<int?> Counts = new List<int?>();
            var CreatedCount = _context.Employees.Sum(p => p.CreatedSuggestions);
            var CompletedCount = _context.Employees.Sum(p => p.CompletedSuggestions);
            Counts.Add(CreatedCount);
            Counts.Add(CompletedCount);
            dataset.Add(Counts);

            return dataset;
        }
    }
}