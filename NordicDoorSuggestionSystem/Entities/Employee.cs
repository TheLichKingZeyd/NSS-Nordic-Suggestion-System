using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Employee")]
    public class Employee
    {
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }

        public byte[]? ProfilePicture { get; set; }
        
        public int? CompletedSuggestions { get; set; }
        public int? CreatedSuggestions { get; set; }

        public string Role { get; set; }

        public Team? Team { get; set; }
        [ForeignKey("Team")]
        public int? TeamID { get; set; }
    }
}
