using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models
{
    public class SuggestionViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Reason { get; set; }
        public string? Solution {get; set;}
        public string? Goal {get; set;}

        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }
        public string? Team { get; set; }
    }
}
