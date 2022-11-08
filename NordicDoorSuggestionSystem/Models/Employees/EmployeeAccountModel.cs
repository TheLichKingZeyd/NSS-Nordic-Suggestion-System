using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Repositories;

namespace NordicDoorSuggestionSystem.Models.Employees
{
    public class EmployeeAccountViewModel
    {
        public int EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string AccountPrivilege { get; set; }
        public string? AccountState { get; set; }
        public string? SgstnCount { get; set; }
        public string Role { get; set; }
        public List<string> AvailableRoles { get; set; }
        public string ValididationErrorMessage { get; set; }
        public List<Employee> Employee { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}
