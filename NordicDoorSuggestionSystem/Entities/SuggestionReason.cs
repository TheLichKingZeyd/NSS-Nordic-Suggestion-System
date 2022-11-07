using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("SuggestionReason")]
    public class SuggestionReason
    {
        public int ReasonID { get; set; } // foreign key maybe?
        public string? ReasonForDenial { get; set; }


    }
}
