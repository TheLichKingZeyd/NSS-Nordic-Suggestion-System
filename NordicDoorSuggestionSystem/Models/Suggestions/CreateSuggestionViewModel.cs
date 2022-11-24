using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models
{
    public class CreateSuggestionViewModel
    {
        public string? Title { get; set; }
        public string? Problem { get; set; }
        public string? Solution { get; set; }
        public string? Goal { get; set; }
        public DateTime? Deadline { get; set; }
        public string Progress { get; set; }

        public IEnumerable<SelectListItem>? ResponsibleList { get; set; }
        [Display(Name = "Ansvarlig")]
        public string? ResponsibleEmployee { get; set; }
    }
}
