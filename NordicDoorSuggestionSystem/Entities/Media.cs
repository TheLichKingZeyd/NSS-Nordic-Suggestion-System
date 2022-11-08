using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Media")]
    public class Media
    {
        public int MediaID { get; set; }
        public DateTime? UploadTime { get; set; }
        
        public byte[]? UploadedFile { get; set; } 

        public Suggestion Suggestion { get; set; }
        [ForeignKey("Suggestion")]
        public int SuggestionID { get; set;}
        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeNumber { get; set;}
        

    }
}