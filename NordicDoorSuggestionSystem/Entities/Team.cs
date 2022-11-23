using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Team")]
    public class Team
    {
        public int TeamID { get; set; }
        [MaxLength(50)]

        public string? TeamName { get; set; }
        [MaxLength(50)]

        public Employee? Employee { get; set; }
        [ForeignKey("Employee")]
        public int? TeamLeader { get; set; }

        public Department? Department { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }

        public int? TeamSgstnCount { get; set; }
    }
}