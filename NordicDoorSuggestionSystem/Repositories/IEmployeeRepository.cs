using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface IEmployeeRepository
    {
        void Update(Employee employee);
        void Add(Employee employee);
        Employee GetEmployeeByNumber(int employeenumber);
        List<Employee> GetEmployees();
        Task Delete(Employee employee);
    }
}