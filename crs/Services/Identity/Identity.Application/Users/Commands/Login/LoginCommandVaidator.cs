namespace Identity.Application.Users.Commands.Login;

internal sealed class LoginCommandVaidator : AbstractValidator<LoginCommand>
{
    public LoginCommandVaidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(Email.MaxLength);

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}
