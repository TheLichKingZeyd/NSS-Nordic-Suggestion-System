using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NordicDoorSuggestionSystem.Models.Administrate
{
    public class CreateTeamViewModel
    {
        public string? TeamName { get; set; }

        public IEnumerable<SelectListItem>? LeaderList { get; set; }
        [Display(Name = "Team Leder")]
        public string? LeaderSelected { get; set; }

        public IEnumerable<SelectListItem>? DepartmentList { get; set; }
        [Display(Name = "Avdeling")]
        public string? DepartmentSelected { get; set; }
    }
}
