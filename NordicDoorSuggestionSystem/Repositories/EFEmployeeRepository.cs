using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using Microsoft.AspNetCore.Identity;

namespace NordicDoorSuggestionSystem.Repositories
{
    public class EFEmployeeRepository : EmployeeRepositoryBase, IEmployeeRepository
    {
        private readonly DataContext dataContext;

        public EFEmployeeRepository(DataContext dataContext, UserManager<User> employeeManager)
        {
            this.dataContext = dataContext;
        }

        public async Task Delete(Employee employee)
        {            
            dataContext.Employees.Remove(employee);
            dataContext.SaveChanges();
        }

        public Employee GetEmployeeByNumber(int employeenumber)
        {
            var employee = dataContext.Employees.FirstOrDefault(x => x.EmployeeNumber == employeenumber);
            return employee;
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
            existingEmployee.CreatedSuggestions = employee.CreatedSuggestions;
            existingEmployee.CompletedSuggestions = employee.CompletedSuggestions;
            existingEmployee.ProfilePicture = employee.ProfilePicture;
            dataContext.SaveChanges();
        }
    }
}
