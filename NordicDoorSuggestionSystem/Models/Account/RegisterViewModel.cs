using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models.Account;

public class RegisterViewModel
{
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "EmployeeNumber")]
    public string EmployeeNumber { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    public IEnumerable<SelectListItem>? RoleList { get; set; }
    public string? RoleSelected { get; set; }
}
