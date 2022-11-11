using Microsoft.AspNetCore.Identity;
using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public abstract class EmployeeRepositoryBase
    {
        UserManager<User> employeeManager;
        public EmployeeRepositoryBase(UserManager<User> employeeManager)
        {
            this.employeeManager = employeeManager;
        }
    }
}
