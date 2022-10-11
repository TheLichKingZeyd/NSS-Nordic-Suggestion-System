using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Repositories;

namespace NordicDoorSuggestionSystem.Models.Users
{
    public class UserViewModel
    {

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string EmployeeNumber { get; set; }
        public string Team { get; set; }
        public string Role { get; set; }
        public List<string> AvailableRoles { get; set; }
        public string ValididationErrorMessage { get; set; }

        public List<UserEntity> Users { get; set; }
        public bool IsAdmin { get; set; }

        public bool isTeamLead { get; set; }

        public bool isEmployee { get; set; }
    }
}
