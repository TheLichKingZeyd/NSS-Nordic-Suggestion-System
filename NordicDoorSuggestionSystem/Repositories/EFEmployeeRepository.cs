using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using Microsoft.AspNetCore.Identity;

namespace NordicDoorSuggestionSystem.Repositories
{
    public class EFEmployeeRepository : EmployeeRepositoryBase, IEmployeeRepository
    {
        private readonly DataContext dataContext;

        public EFEmployeeRepository(DataContext dataContext, UserManager<User> employeeManager) : base(employeeManager)
        {
            this.dataContext = dataContext;
        }

        public void Delete(int employeenumber)
        {
            Employee? employee = GetEmployeeByNumber(employeenumber);
            if (employee == null)
                return;
            dataContext.Employees.Remove(employee);
            dataContext.SaveChanges();
        }

        private Employee? GetEmployeeByNumber(int employeenumber)
        {
            return dataContext.Employees.FirstOrDefault(x => x.EmployeeNumber == employeenumber);
        }

        public List<Employee> GetEmployees()
        {
            return dataContext.Employees.ToList();
        }

        public void Add(Employee employee)
        {
            var existingEmployee = GetEmployeeByNumber(employee.EmployeeNumber);
            if (existingEmployee != null)
            {
                throw new Exception("User already exists found");
            }
            dataContext.Employees.Add(employee);
            dataContext.SaveChanges();
        }
        public void Update(Employee employee)
        {
            var existingEmployee = GetEmployeeByNumber(employee.EmployeeNumber);
            if (existingEmployee == null)
            {
                throw new Exception("User not found");
            }
            existingEmployee.EmployeeNumber = employee.EmployeeNumber;
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.TeamID = employee.TeamID;
            dataContext.SaveChanges();
        }
    }
}
