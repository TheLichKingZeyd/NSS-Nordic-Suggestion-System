using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Media")]
    public class MediaEntity
    {
        [Key]
        public int MediaID { get; set; }
        public DateTime? UploadTime { get; set; }
        public int EmployeeNumber { get; set; }
        public EmployeeEntity EmployeeEntity { get; set; }
        public Blob? UploadedFile { get; set; } // or use filestream
        public string? SgstnID { get; set; }
        public SuggestionEntity SuggestionEntity { get; set; }

    }
}
