using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NordicDoorSuggestionSystem.Models.Administrate
{
    public class EditTeamViewModel
    {
        public int TeamID { get; set; }

        public string? TeamName { get; set; }

        public IEnumerable<SelectListItem>? LeaderList { get; set; }
        [Display(Name = "Team Leder")]
        public string? LeaderSelected { get; set; }
    }
}
