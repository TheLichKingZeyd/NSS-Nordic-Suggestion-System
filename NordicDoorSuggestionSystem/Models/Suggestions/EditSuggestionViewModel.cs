using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models
{
    public class EditSuggestionViewModel
    {
        public string? SuggestionID { get; set; }
        public string? Title { get; set; }

        public IEnumerable<SelectListItem>? ResponsibleList { get; set; }
        [Display(Name = "Ansvarlig")]
        public string? ResponsibleEmployee { get; set; }
        public string? Problem { get; set; }
        public string? Solution { get; set; }
        public string? Goal { get; set; }

        public IEnumerable<SelectListItem>? ProgressList { get; set; }
        [Display(Name = "Status")]
        public string? Progress { get; set; }
        public DateTime? Deadline { get; set; }
        public int TeamID { get; set; }
    }
}
