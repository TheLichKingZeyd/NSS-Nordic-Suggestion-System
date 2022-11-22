using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Department")]
    public class Department
    {
        public int DepartmentID { get; set; }
        [MaxLength(50)]
        public string? DepartmentName { get; set; }
        [MaxLength(50)]
        public int? TeamCount { get; set; }
    }
}