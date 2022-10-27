using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("SgstnReason")]
    public class SgstnReasonEntity
    {
        [Key]
        public int SgstnID { get; set; } // foreign key maybe?
        public string? ReasonForDenial { get; set; }


    }
}
