using System.ComponentModel.DataAnnotations;

namespace NordicDoorSuggestionSystem.Models.Account;

public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
