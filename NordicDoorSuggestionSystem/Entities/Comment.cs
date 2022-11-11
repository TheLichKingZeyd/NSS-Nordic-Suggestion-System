using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Comment")]
    public class Comment
    {
        public int CommentID { get; set; }
        public string? Content { get; set; }
        [Timestamp]
        public DateTime? CommentTime { get; set; }
        
        public Suggestion? Suggestion { get; set; }
        [ForeignKey("Suggestion")]
        public int? SuggestionID { get; set; }
        public Employee? Employee { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeNumber { get; set; }

    }
}