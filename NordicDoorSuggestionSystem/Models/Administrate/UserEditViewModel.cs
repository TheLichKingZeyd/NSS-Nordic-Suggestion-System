using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NordicDoorSuggestionSystem.Models.Administrate
{
    public class UserEditViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string EmployeeNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PreviousRole { get; set; }

        public IEnumerable<SelectListItem>? RoleList { get; set; }
        [Display(Name = "Kontotype")]
        public string? RoleSelected { get; set; }
    }
}
