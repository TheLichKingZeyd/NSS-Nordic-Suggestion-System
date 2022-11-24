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
        private readonly UserManager<User> _userManager;



        public SuggestionRepository(DataContext dataContext, UserManager<User>userManager)
        {
            this._context = dataContext;
            this._userManager = userManager;
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

        public async Task<List<Suggestion>> QueryTitleOnEmployee(string title, int employee)
        {
            var suggestions = await _context.Suggestion.Where(s => s.Title!.Contains(title)).ToListAsync();
            for (var i = 0; i < suggestions.Count(); i++)
            {
                if (employee != suggestions[i].EmployeeNumber)
                {
                    suggestions.Remove(suggestions[i]);
                    i--;
                }
            }
            return suggestions;
        }

        public async Task<List<Suggestion>> QueryTitleOnResponsible(string title, int employee)
        {
            var suggestions = await _context.Suggestion.Where(s => s.Title!.Contains(title)).ToListAsync();
            for (var i = 0; i < suggestions.Count(); i++)
            {
                if (employee != suggestions[i].ResponsibleEmployee)
                {
                    suggestions.Remove(suggestions[i]);
                    i--;
                }
            }
            return suggestions;
        }

        public async Task<List<Suggestion>> QueryProblem(string problem)
        {
            return await _context.Suggestion.Where(s => s.Problem!.Contains(problem)).ToListAsync();
        }
        
        // This is a task that returns a list with the user's suggestions.
        // Will test when login is possible. 

        /*public async Task<List<Suggestion>> MySuggestions()
        {
            // var user = await _userManager.GetUserAsync(HttpContext.User);
            return await _context.Suggestion.Where(s => s.EmployeeNumber == ).ToListAsync();
        } */
        public async Task<List<Suggestion>> QueryEmployee(int employeeNumber)
        {
            return await _context.Suggestion.Where(s => s.EmployeeNumber!.Equals(employeeNumber)).ToListAsync();
        }

        public async Task<List<Suggestion>> QueryResponsible(int responsibleNumber)
        {
            return await _context.Suggestion.Where(s => s.ResponsibleEmployee!.Equals(responsibleNumber)).ToListAsync();
        }


        public async Task Update(Suggestion suggestion) 
        {
            _context.Suggestion.Update(suggestion);
        }

        public async Task SaveChanges(){
            await _context.SaveChangesAsync();
        }
    }
}
