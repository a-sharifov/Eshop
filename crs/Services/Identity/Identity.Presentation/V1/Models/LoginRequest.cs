namespace Identity.Presentation.V1.Models;

public sealed record LoginRequest(
    [Required] string Email, 
    [Required] string Password);
