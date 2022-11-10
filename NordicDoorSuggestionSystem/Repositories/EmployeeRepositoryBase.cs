using Microsoft.AspNetCore.Identity;
using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public abstract class EmployeeRepositoryBase
    {
        UserManager<Employee> employeeManager;
        public EmployeeRepositoryBase(UserManager<Employee> employeeManager)
        {
            this.employeeManager = employeeManager;
        }

        public bool IsAdmin(int employeeNumber)
        {
            var identity = employeeManager.Users.FirstOrDefault(x => x.UserName == employeeNumber.ToString());
            var existingRoles = employeeManager.GetRolesAsync(identity).Result;
            return existingRoles.FirstOrDefault(x => x == "Administrator") != null;
        }
        /* public bool IsTeamLead(string email)
        {
            var identity = userManager.Users.FirstOrDefault(x => x.Email == email);
            var existingRoles = userManager.GetRolesAsync(identity).Result;
            return existingRoles.FirstOrDefault(x => x == "Teamleder") != null;
        }
        public bool IsEmployee(string email)
        {
            var identity = userManager.Users.FirstOrDefault(x => x.Email == email);
            var existingRoles = userManager.GetRolesAsync(identity).Result;
            return existingRoles.FirstOrDefault(x => x == "Ansatt") != null;
        } */


        protected void SetRoles(string userEmail, List<string> roles)
        {
            var identity = employeeManager.Users.FirstOrDefault(x => x.Email == userEmail);
            var existingRoles = employeeManager.GetRolesAsync(identity).Result;

            //Remove role access before adding new
            foreach (var existingRole in existingRoles)
            {
                var result = employeeManager.RemoveFromRoleAsync(identity, existingRole).Result;
            }
            foreach (var role in roles)
            {
                if (!employeeManager.IsInRoleAsync(identity, role).Result)
                {
                    var result = employeeManager.AddToRoleAsync(identity, role).Result;
                }
            }
        }
        public UserManager<IdentityUser> UserManager { get; }
    }
}
