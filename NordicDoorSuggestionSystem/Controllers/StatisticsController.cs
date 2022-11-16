using Microsoft.AspNetCore.Mvc;
using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections.Generic;

namespace NordicDoorSuggestionSystem.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly DataContext _context;
        private readonly ISqlConnector sqlConnector;

         public StatisticsController(DataContext context, ISqlConnector sqlConnector)
        {
            _context = context;
            this.sqlConnector = sqlConnector;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowStatisticsData()
        {
            StatisticsViewModel vm = new StatisticsViewModel();
            var employeeCounts = _context.Employees.OrderByDescending(x => x.SuggestionCount).ToList();
            vm.EmployeeList = employeeCounts;
            
            var teamCounts = _context.Team.OrderByDescending(x => x.TeamSgstnCount).ToList();
            vm.BestTeamList = teamCounts;

            return View(vm);
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

            List<int?> DepartmentCount = _context.Team.Where(p=>p.DepartmentID == 1 || p.DepartmentID == 2 || p.DepartmentID == 3 || p.DepartmentID == 4).Select(p=>p.TeamSgstnCount).ToList();
            dataset.Add(DepartmentCount);
            
            return dataset;
        }

        private void RunCommand(string sql)
        {
            using (var connection = sqlConnector.GetDbConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private IDataReader ReadData(string query, IDbConnection connection)
        {
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            return command.ExecuteReader();
        }
    }
}