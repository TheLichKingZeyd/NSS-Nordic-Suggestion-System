using System.ComponentModel.DataAnnotations;
using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Models
{
    public class StatisticsViewModel
    {
        public virtual List<Employee>? EmployeeList { get; set; }

        public virtual List<Team>? BestTeamList { get; set; }
    }
}