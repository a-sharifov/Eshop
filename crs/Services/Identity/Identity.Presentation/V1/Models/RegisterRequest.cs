namespace Identity.Presentation.V1.Models;

public record RegisterRequest(
    [Required] string Email,
    [Required] string Password,
    [Required] string ConfirmPassword,
    [Required] string FirstName,
    [Required] string LastName,
    [Required] string Role,
    [Required] string ReturnUrl);
