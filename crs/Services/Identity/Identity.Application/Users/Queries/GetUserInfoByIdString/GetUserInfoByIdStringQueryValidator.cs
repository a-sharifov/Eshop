namespace Identity.Application.Users.Queries.GetUserInfoByIdString;

internal sealed class GetUserInfoByIdStringQueryValidator : AbstractValidator<GetUserInfoByIdStringQuery>
{
    public GetUserInfoByIdStringQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Id)
            .Must(x => Guid.TryParse(x, out _))
            .WithMessage("Invalid Id");
    }
}
