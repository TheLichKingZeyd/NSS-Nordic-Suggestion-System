using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Employee")]
    public class EmployeeEntity
    {
        [Key]
        public int EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? AccountPrivilege { get; set; }
        public bool AccountState { get; set; }
        public string? Team { get; set; }
        public Blob? ProfilePicture { get; set; }
        //public Filestream? ProfilePicture { get; set; }
        public int? TeamID { get; set; }
        public TeamEntity TeamEntity { get; set; }

    }
}
