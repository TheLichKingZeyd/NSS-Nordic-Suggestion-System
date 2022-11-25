using NordicDoorSuggestionSystem.Entities;
using System.Web;
using Microsoft.AspNetCore.Identity;

namespace NordicDoorSuggestionSystem.Models.Employees
{
    public class ProfileViewModel
    {
        public int EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AccountState { get; set; }
        public string Role { get; set; }
        public IFormFile? NewProfilePicture { get; set; }
        public int? TeamID { get; set; }
        public int? SuggestionCount { get; set; }
        public string? TeamName { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}