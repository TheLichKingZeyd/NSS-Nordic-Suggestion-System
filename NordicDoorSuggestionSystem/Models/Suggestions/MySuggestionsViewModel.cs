namespace NordicDoorSuggestionSystem.Models
{
    public class MySuggestionsViewModel
    {
        public string? Title { get; set; }
        public int? ResponsibleEmployee { get; set; }
        public string? Problem { get; set; }
        public string? Solution { get; set; }
        public string? Goal { get; set; }
        public DateTime? Deadline { get; set; }
        public short? Progress { get; set; }
        public int EmployeeNumber { get; set;}
        public int TeamID { get; set; }
    }
}
