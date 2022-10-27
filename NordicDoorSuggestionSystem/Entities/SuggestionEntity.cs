using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Suggestion")]
    public class SuggestionEntity
    {
        public int SgstnID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? Team { get; set; }

    }
}
