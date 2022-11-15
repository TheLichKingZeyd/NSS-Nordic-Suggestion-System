using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models
{
    public class TeamViewModel
    {
        public int TeamID { get; set; }
        public string? TeamName { get; set; }
        public string? TeamLeader { get; set; }
        public int? DepartmentID { get; set; }
    }
}