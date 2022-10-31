using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models
{
    public class SuggestionViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Context { get; set; }

        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }
        public string? Team { get; set; }
    }
}
