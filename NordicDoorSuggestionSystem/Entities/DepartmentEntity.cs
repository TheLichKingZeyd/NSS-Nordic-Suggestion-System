using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Department")]
    public class DepartmentEntity
    {
        [Key]
        public int DepartmentID { get; set; }
        [MaxLength(50)]
        public string? DepartmentName { get; set; }
        [MaxLength(50)]
        public string? DepartmentLeader { get; set; }
    }
}
