using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Suggestion")]
    public class Suggestion
    {
        public int SuggestionID { get; set; }
        
        public int? ResponsibleEmployee { get; set; }

        [Timestamp]
        public byte[] UploadTime { get; set; }
        public string? Title { get; set; }
        public string? Problem { get; set; }
        public string? Solution { get; set; }
        public string? Goal { get; set; }
        public DateTime? Deadline { get; set; }
        public short? Progress { get; set; }

        public Employee Employee  { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeNumber { get; set;}
        
        
        public Team Team { get; set; } 
        [ForeignKey("Team")]
        public int TeamID { get; set; }

    }
}
