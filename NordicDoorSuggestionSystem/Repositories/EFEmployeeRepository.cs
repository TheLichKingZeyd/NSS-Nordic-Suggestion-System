using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using Microsoft.AspNetCore.Identity;

namespace NordicDoorSuggestionSystem.Repositories
{
    public class EFEmployeeRepository : EmployeeRepositoryBase, IEmployeeRepository
    {
        private readonly DataContext dataContext;

        public EFEmployeeRepository(DataContext dataContext, UserManager<IdentityUser> employeeManager) : base(employeeManager)
        {
            this.dataContext = dataContext;
        }

        public void Delete(string employeenumber)
        {
            EmployeeEntity? employee = GetEmployeeByNumber(employeenumber);
            if (employee == null)
                return;
            dataContext.Employees.Remove(employee);
            dataContext.SaveChanges();
        }

        private EmployeeEntity? GetEmployeeByNumber(string employeenumber)
        {
            return dataContext.Employees.FirstOrDefault(x => x.EmployeeNumber.ToString() == employeenumber);
        }

        public List<EmployeeEntity> GetEmployees()
        {
            return dataContext.Employees.ToList();
        }

        public void Add(EmployeeEntity employee)
        {
            var existingEmployee = GetEmployeeByNumber(employee.EmployeeNumber.ToString());
            if (existingEmployee != null)
            {
                throw new Exception("User already exists found");
            }
            dataContext.Employees.Add(employee);
            dataContext.SaveChanges();
        }
        public void Update(EmployeeEntity employee, List<string> roles)
        {
            var existingEmployee = GetEmployeeByNumber(employee.EmployeeNumber.ToString());
            if (existingEmployee == null)
            {
                throw new Exception("User not found");
            }
            existingEmployee.EmployeeNumber = employee.EmployeeNumber;
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Role = employee.Role;

            dataContext.SaveChanges();
            SetRoles(employee.EmployeeNumber.ToString(), roles);
        }
    }
}