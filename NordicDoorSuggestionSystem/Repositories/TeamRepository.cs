using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }

        public Team GetTeam(int teamID)
        {
            Team team = _context.Team.FirstOrDefault(x => x.TeamID == teamID);
            return team;
            
        }

        public Team? GetTeamByNumber(int teamID)
        {
            return _context.Team.FirstOrDefault(x => x.TeamID == teamID);
        }
    }
}
