using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("SgstnReason")]
    public class SgstnReasonEntity
    {
        public int ReasonID { get; set; } // foreign key maybe?
        public string? ReasonForDenial { get; set; }


    }
}
