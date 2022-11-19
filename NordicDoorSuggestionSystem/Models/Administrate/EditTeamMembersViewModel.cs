using System.ComponentModel.DataAnnotations;
using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Models
{
    public class EditTeamMemberViewModel
    {
        public virtual List<Employee> EmployeeList { get; set; }
        public virtual List<Team>? TeamList { get; set; }
    }
}