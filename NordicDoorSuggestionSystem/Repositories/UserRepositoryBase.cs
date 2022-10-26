using Microsoft.AspNetCore.Identity;

namespace NordicDoorSuggestionSystem.Repositories
{
    public abstract class UserRepositoryBase
    {
        UserManager<IdentityUser> userManager;
        public UserRepositoryBase(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public bool IsAdmin(string email)
        {
            var identity = userManager.Users.FirstOrDefault(x => x.Email == email);
            var existingRoles = userManager.GetRolesAsync(identity).Result;
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
            var identity = userManager.Users.FirstOrDefault(x => x.Email == userEmail);
            var existingRoles = userManager.GetRolesAsync(identity).Result;

            //Remove role access before adding new
            foreach (var existingRole in existingRoles)
            {
                var result = userManager.RemoveFromRoleAsync(identity, existingRole).Result;
            }
            foreach (var role in roles)
            {
                if (!userManager.IsInRoleAsync(identity, role).Result)
                {
                    var result = userManager.AddToRoleAsync(identity, role).Result;
                }
            }
        }
        public UserManager<IdentityUser> UserManager { get; }
    }
}
