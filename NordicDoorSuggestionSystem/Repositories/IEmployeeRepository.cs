using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface IEmployeeRepository
    {
        void Update(EmployeeEntity user, List<string> roles);
        void Add(EmployeeEntity user);
        List<EmployeeEntity> GetEmployees();
        void Delete(string email);
        bool IsAdmin(string email);
        // bool IsTeamLead(string email);
        // bool IsEmployee(string email);
    }
}