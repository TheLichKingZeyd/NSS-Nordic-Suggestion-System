using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface ITeamRepository
    {
        Team GetTeam(int teamID);
    }
}
