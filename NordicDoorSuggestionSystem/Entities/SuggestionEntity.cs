using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Suggestion")]
    public class SuggestionEntity
    {
        [Key]
        public int SgstnID { get; set; }
        public int EmployeeNumber { get; set; }
        public EmployeeEntity EmployeeEntity { get; set; }
        public int? TeamID { get; set; }
        public TeamEntity TeamEntity { get; set; }
        //public string? EmployeeNumber { get; set; }
        //public EmployeeEntity employeeEntity { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public DateTime? Deadline { get; set; }
        //public Dateonly? Deadline { get; set; }
        public string? Title { get; set; }
        public string? ProbDescr { get; set; }
        public string? Solution { get; set; }
        public string? Goal { get; set; }
        public bool HasMediaAttachments { get; set; }
        public short? Progress { get; set; }
        public bool HasReasoning { get; set; }


    }
}
