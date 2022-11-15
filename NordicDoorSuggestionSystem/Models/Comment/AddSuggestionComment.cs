using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models
{
    public class AddSuggestionComment
    {
        public int CommentID { get; set; }
        public int EmployeeNumber { get; set; }
        public int SuggestionID { get; set; }
        public string? Content { get; set; }
        public DateTime? CommentTime { get; set; }
    }
}