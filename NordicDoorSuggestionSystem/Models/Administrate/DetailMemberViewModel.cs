using System.ComponentModel.DataAnnotations;
using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Models
{
    public class DetailMemberViewModel
    {
        public int TeamID { get; set; }
        public string? TeamName { get; set; }
        public virtual List<Employee>? EmployeeList { get; set; }
        public virtual List<Team>? TeamList { get; set; }
    }
}