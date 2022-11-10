using Microsoft.AspNetCore.Identity;
using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public abstract class EmployeeRepositoryBase
    {
        UserManager<IdentityUser> employeeManager;
        public EmployeeRepositoryBase(UserManager<IdentityUser> employeeManager)
        {
            this.employeeManager = employeeManager;
        }
    }
}
