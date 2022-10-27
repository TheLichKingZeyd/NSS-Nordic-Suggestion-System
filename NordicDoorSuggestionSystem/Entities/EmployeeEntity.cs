using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Employees")]
    public class EmployeeEntity
    {
        public int EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string AccountPrivilege { get; set; }
        public bool? AccountState { get; set; }
        public string? SgstnCount { get; set; }
        public string? Role { get; set; }
    }
}
