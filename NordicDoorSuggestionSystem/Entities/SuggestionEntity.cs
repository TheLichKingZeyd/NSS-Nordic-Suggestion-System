using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorSuggestionSystem.Entities
{
    [Table("Suggestions")]
    public class SuggestionEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Reason {get; set;}
        public string? Solution {get; set;}
        public string? Goal {get; set;}
        public DateTime DeadlineDate { get; set; }
        public string? Team { get; set; }

    }
}
