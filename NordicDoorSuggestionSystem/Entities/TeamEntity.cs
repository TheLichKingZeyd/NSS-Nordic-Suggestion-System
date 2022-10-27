using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Team")]
    public class TeamEntity
    {
        public int TeamID { get; set; }
        [MaxLength(50)]
        public string? TeamName { get; set; }
        [MaxLength(50)]
        public string? TeamLeader { get; set; }
        public ushort? TeamSgstnCount { get; set; }
        // maybe use a normal int if a unsigned short proves too small
        public int? DepartmentID { get; set; }

        public DepartmentEntity DepartmentEntity { get; set; }

    }
}
