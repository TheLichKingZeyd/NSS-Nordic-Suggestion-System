using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Employee")]
    public class EmployeeEntity
    {
        public int EmployeeNumber { get; set; }
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(15)]
        public string? Role { get; set; }
        public bool AccountState { get; set; }
        public byte[] ProfilePicture { get; set; }
        public int? TeamID { get; set; }
        public TeamEntity TeamEntity { get; set; }
        public ushort? SgstnCount { get; set; }
    }
}
