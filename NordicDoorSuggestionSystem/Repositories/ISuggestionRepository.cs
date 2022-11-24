using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface ISuggestionRepository
    {
        Task Add(Suggestion suggestion);
        Task Update(Suggestion suggestion);
        Task<List<Suggestion>> GetSuggestions();        
        Task<List<Suggestion>> QueryTitle(string title);
        Task<List<Suggestion>> QueryProblem(string problem);
        Task<Suggestion> GetSuggestion(int? suggestionId);
        Task Delete(Suggestion suggestion);
        Task SaveChanges();
        Task<List<Suggestion>> QueryEmployee(int employeeNumber);
        Task<List<Suggestion>> QueryResponsible(int responsibleNumber);
    }
}