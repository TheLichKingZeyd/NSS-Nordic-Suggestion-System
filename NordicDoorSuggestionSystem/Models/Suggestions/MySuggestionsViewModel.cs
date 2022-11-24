using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models
{
    public class MySuggestionsViewModel
    {
        public int SuggestionID { get; set; }
        public string? Title { get; set; }
        public string? ResponsibleEmployee { get; set; }
        public string? Problem { get; set; }
        public string? Solution { get; set; }
        public string? Goal { get; set; }
        public DateTime? Deadline { get; set; }
        public string? Progress { get; set; }
        public string Maker { get; set;}
        public string TeamName { get; set; }
    }
}
