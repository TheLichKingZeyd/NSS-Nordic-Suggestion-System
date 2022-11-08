using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface IEmployeeRepository
    {
        void Update(Employee user, List<string> roles);
        void Add(Employee user);
        List<Employee> GetEmployees();
        void Delete(int employeenumber);
        bool IsAdmin(int employeename);
        // bool IsTeamLead(string email);
        // bool IsEmployee(string email);
    }
}