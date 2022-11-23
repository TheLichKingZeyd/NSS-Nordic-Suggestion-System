using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NordicDoorSuggestionSystem.Models.Administrate
{
    public class TeamsViewModel
    {
        public int TeamID { get; set; }

        public string TeamName { get; set; }

        public string TeamLeader { get; set; }

        public int TeamSgstnCount { get; set; }

        public string DepartmentName { get; set; }
    }
}
