using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Comment")]
    public class CommentEntity
    {
        [Key]
        public int CommentID { get; set; }
        public DateTime? CommentTime { get; set; }
        public int? SgstnID { get; set; }
        public SuggestionEntity SuggestionEntity { get; set; }    
        public string? EmployeeNumber { get; set; }
        public EmployeeEntity EmployeeEntity { get; set; }  
        public string? Content { get; set; }
        // needs to limit the string size to that of an sql tiny text

    }
}