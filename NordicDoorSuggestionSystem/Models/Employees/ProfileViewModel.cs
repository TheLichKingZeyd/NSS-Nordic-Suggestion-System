using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Models.Employees
{
    public class ProfileViewModel
    {
        public int EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AccountState { get; set; }
        public string? SgstnCount { get; set; }
        public string Role { get; set; }
        public int? TeamID { get; set; }
        public int? CreatedSuggestions { get; set; }
        public int? CompletedSuggestions { get; set; }
        public string? TeamName { get; set; }
    }
}