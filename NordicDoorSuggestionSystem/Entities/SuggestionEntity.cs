using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Suggestion")]
    public class SuggestionEntity
    {
        public int SgstnID { get; set; }
        public int EmployeeNumber { get; set; }
        public EmployeeEntity EmployeeEntity { get; set; }
        public int? TeamID { get; set; }
        public TeamEntity TeamEntity { get; set; }
        public int? ResposibleEmployeeNumber { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public DateOnly? Deadline { get; set; }
        public string? Title { get; set; }
        public string? ProbDescr { get; set; }
        public string? Solution { get; set; }
        public string? Goal { get; set; }
        public bool HasMediaAttachments { get; set; }
        public short? Progress { get; set; }
        public bool HasReasoning { get; set; }

    }
}
