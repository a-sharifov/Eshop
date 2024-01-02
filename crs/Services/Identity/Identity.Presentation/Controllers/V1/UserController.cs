using Identity.Application.Users.Commands.Login;
using Identity.Application.Users.Commands.Register;
using Identity.Application.Users.Commands.UpdateRefreshToken;

namespace Identity.Presentation.Controllers.V1;

[Route("api/v{version:apiVersion}/users")]
[ApiVersion("1.0")]
public sealed class UserController(ISender sender) : ApiController(sender)
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ? Ok(result.Value)
            : HandleFailure(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ? Ok()
            : HandleFailure(result);
    }

    [HttpPost("update-refresh-token")]
    public async Task<IActionResult> UpdateRefreshToken([FromBody] UpdateRefreshTokenCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ? Ok(result.Value)
            : HandleFailure(result);
    }
}
