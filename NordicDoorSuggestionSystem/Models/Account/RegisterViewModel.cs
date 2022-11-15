using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models.Account;

public class RegisterViewModel
{
    [Required(ErrorMessage ="Skriv den ansattes ansattnummer.")]
    [DataType(DataType.Text)]
    [Display(Name = "Ansattnummer")]
    public int EmployeeNumber { get; set; }

    [Required(ErrorMessage = "Skriv den ansattes fornavn.")]
    [DataType(DataType.Text)]
    [Display(Name = "Fornavn")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Skriv den ansattes etternavn.")]
    [DataType(DataType.Text)]
    [Display(Name = "Etternavn")]
    public string LastName { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Passord")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Gjenta passord")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    public IEnumerable<SelectListItem>? RoleList { get; set; }
    [Display(Name = "Kontotype")]
    public string? RoleSelected { get; set; }
}
