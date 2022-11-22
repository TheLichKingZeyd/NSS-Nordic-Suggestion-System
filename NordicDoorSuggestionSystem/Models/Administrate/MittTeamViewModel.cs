using System.ComponentModel.DataAnnotations;
using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Models
{
    public class MittTeamViewModel
    {
        public int? TeamID { get; set; }
        public string? TeamName { get; set; }
        public int EmployeeNumber { get; set; }
        public virtual List<Employee>? EmployeeTeamList { get; set; }
    }
}