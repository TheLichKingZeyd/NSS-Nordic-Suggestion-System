using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NordicDoorSuggestionSystem.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;

        public TeamRepository(DataContext dataContext, UserManager<User>userManager)
        {
            this._context = dataContext;
            this._userManager = userManager;
        }

        public Team GetTeam(int? teamID)
        {
            if (teamID == null)
            {
                throw new NullReferenceException("TeamID can not be null");
            } 
            else
            {
                var team = _context.Team.FindAsync(teamID);
                if (team == null)
                {
                    return null;
                } 
                else
                {
                    return _context.Team.FirstOrDefault(x => x.TeamID == teamID);
                }
            }
        }

        public Task<List<Team>> GetTeams()
        {
            return _context.Team.ToListAsync();
        }

        public Task<List<Team>> GetTeamsInDepartment(int departmentId)
        {
            return _context.Team.Where(x => x.DepartmentID == departmentId).ToListAsync();
        }

        public async Task AddTeam(Team team)
        {            
            _context.Team.Add(team);
            await SaveChanges();
        }

        public async Task DeleteTeam(Team team)
        {
            _context.Team.Remove(team);
            await SaveChanges();
        }
        public async Task SaveChanges(){
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeam(Team team) 
        {
            _context.Team.Update(team);
            await SaveChanges();
        }
    }
}
