using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> GetTeam(int? TeamID);
        Task<List<Team>> GetTeams();
        Task DeleteTeam(Team team);
        Task SaveChanges();
        Task Update(Team team);
        // Task<List<Team>> QueryTeam (int employeeNumber);
    }
}
