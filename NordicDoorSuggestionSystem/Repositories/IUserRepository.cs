using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Repositories
{
    public interface IUserRepository
    {
        void Update(UserEntity user, List<string> roles);
        void Add(UserEntity user);
        List<UserEntity> GetUsers();
        void Delete(string email);
        bool IsAdmin(string email);
        // bool IsTeamLead(string email);
        // bool IsEmployee(string email);
    }
}