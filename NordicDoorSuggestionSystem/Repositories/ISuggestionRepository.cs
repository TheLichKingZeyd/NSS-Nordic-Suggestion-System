using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface ISuggestionRepository
    {
        Task Add(Suggestion suggestion);
        Task Update(Suggestion suggestion);
        Task<List<Suggestion>> GetSuggestions();        
        Task<List<Suggestion>> QuerySuggestions(string title);
        Task<Suggestion> GetSuggestion(int? suggestionId);
        Task Delete(Suggestion suggestion);
        Task SaveChanges();
    }
}