using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Media")]
    public class MediaEntity
    {
        public int MediaID { get; set; }
        public DateTime? UploadTime { get; set; }
        public int EmployeeNumber { get; set; }
        public EmployeeEntity EmployeeEntity { get; set; }
        public FileStream UploadedFile { get; set; } 
        public string? SgstnID { get; set; }
        public SuggestionEntity SuggestionEntity { get; set; }

    }
}