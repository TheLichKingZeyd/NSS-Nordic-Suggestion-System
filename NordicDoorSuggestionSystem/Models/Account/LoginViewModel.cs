using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models.Account;

public class LoginViewModel
{
    [Required]
    [DataType(DataType.Text)]
    [Display (Name = "Ansatt nummer")]
    public string EmployeeNumber { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}
