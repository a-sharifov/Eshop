namespace Identity.Presentation.V1.Models;

public record class UpdateRefreshTokenRequest(
    [Required] string Token, 
    [Required] string RefreshToken);
