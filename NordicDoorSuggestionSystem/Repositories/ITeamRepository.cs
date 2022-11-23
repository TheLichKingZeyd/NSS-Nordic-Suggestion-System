using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface ITeamRepository
    {
        Team GetTeam(int? TeamID);
        Task<List<Team>> GetTeams();
        Task<List<Team>> GetTeamsInDepartment(int departmentId);
        Task AddTeam(Team team);
        Task DeleteTeam(Team team);
        Task SaveChanges();
        Task Update(Team team);
        // Task<List<Team>> QueryTeam (int employeeNumber);
    }
}
