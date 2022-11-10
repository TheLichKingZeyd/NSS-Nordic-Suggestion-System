using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models
{
    public class EditSuggestionViewModel
    {
        public string? SuggestionID { get; set; }
        public string? Title { get; set; }
        public int? ResponsibleEmployee { get; set; }
        public string? Problem { get; set; }
        public string? Solution { get; set; }
        public string? Goal { get; set; }
        public DateTime? Deadline { get; set; }
        public int TeamID { get; set; }
    }
}
