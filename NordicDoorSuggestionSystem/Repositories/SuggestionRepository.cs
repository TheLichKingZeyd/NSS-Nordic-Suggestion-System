using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NordicDoorSuggestionSystem.Repositories
{
    public class SuggestionRepository : ISuggestionRepository
    {
        // private readonly UserManager<IdentityUser> _userManager;
        private readonly DataContext _context;



        public SuggestionRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }

        public async Task Add(Suggestion suggestion)
        {
            if (suggestion == null) 
                throw new NullReferenceException("Suggestion can not be null");
            
            _context.Add(suggestion);
        }

        public async Task Delete(Suggestion suggestion)
        {
            _context.Suggestion.Remove(suggestion);
        }

        public async Task<Suggestion> GetSuggestion(int? suggestionId)
        {
            if (suggestionId == null) 
                throw new NullReferenceException("SuggestionId can not be null");

            var suggestion = await _context.Suggestion.FindAsync(suggestionId);
            
            if (suggestion == null) 
                return null;

            return suggestion;
        }

        public Task<List<Suggestion>> GetSuggestions()
        {
            return _context.Suggestion.ToListAsync();
        }

        public async Task<List<Suggestion>> QueryTitle(string title)
        {
            return await _context.Suggestion.Where(s => s.Title!.Contains(title)).ToListAsync();
        }

        public async Task<List<Suggestion>> QueryProblem(string problem)
        {
            return await _context.Suggestion.Where(s => s.Problem!.Contains(problem)).ToListAsync();
        }
        
        // This is a task that returns a list with the user's suggestions.
        // Will test when login is possible. 

        /* public async Task<List<Suggestion>> MySuggestions()
        {
            
            return await _context.Suggestion.Where(s => s.UserID == userID).ToListAsync();
        } */

        public async Task Update(Suggestion suggestion) 
        {
            _context.Suggestion.Update(suggestion);
        }

        public async Task SaveChanges(){
            await _context.SaveChangesAsync();
        }
    }
}
