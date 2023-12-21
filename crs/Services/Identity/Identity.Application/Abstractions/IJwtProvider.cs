namespace Identity.Application.Abstractions;

public interface IJwtProvider
{
    public string CreateToken(User user);
}
