namespace Identity.Application.Users.Commands.UpdateRefreshToken;

internal sealed class UpdateRefreshTokenCommandValidator : AbstractValidator<UpdateRefreshTokenCommand>
{
    public UpdateRefreshTokenCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty();

        RuleFor(x => x.RefreshToken)
            .NotEmpty();
    }
}
