using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface IEmployeeRepository
    {
        void Update(Employee enmployee, List<string> roles);
        void Add(Employee employee);
        List<Employee> GetEmployees();
        void Delete(int employeenumber);
    }
}