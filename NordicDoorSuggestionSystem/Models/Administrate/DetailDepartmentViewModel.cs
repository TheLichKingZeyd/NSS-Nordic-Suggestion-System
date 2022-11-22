using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Models.Administrate
{
    public class DetailDepartmentViewModel
    {
        public string DepartmentName { get; set; }

        public virtual List<Team>? TeamList { get; set; }
    }
}
