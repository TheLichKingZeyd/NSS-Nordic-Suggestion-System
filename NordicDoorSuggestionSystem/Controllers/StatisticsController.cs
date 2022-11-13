using Microsoft.AspNetCore.Mvc;
using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Models;

namespace NordicDoorSuggestionSystem.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly DataContext _context;

         public StatisticsController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowStatisticsData()
        {
            return View();
        }

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

        [HttpPost]
        public List<object> GetDepartmentData()
        {
            List<object> dataset = new List<object>();

            List<string?> labelsFor = _context.Departments.Select(p=>p.DepartmentName).ToList();

            dataset.Add(labelsFor);

            List<int> DepartmentCount = new List<int>(new int[] { 35, 37, 81, 21 } );
            dataset.Add(DepartmentCount);
            
            return dataset;
        }
    }
}