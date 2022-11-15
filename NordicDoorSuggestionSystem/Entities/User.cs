using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("User")]
    public class User : IdentityUser
    {
        public int EmployeeNumber { get; set; }     

        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }
        

    }
}
