using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface IEmployeeRepository
    {
        void Update(Employee employee);
        void Add(Employee employee);
        List<Employee> GetEmployees();
        void Delete(int employeenumber);
    }
}