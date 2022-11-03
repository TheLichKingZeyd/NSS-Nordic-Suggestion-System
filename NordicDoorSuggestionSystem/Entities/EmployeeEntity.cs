using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Employee")]
    public class EmployeeEntity
    {
        public int EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public string? AccountPrivilege { get; set; }
        public string? Role { get; set; }
        public bool AccountState { get; set; }
        public string? Team { get; set; }
        public byte[] ProfilePicture { get; set; }
        public int? TeamID { get; set; }
        public TeamEntity TeamEntity { get; set; }
        public ushort? SgstnCount { get; set; }
    }
}
