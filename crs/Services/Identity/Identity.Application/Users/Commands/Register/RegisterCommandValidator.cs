﻿namespace Identity.Application.Users.Commands.Register;

internal sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(Email.MaxLength);

        RuleFor(x => x.Password)
            .NotEmpty();

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(FirstName.MaxLength);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(LastName.MaxLength);

        RuleFor(x => x.Role)
            .NotEmpty()
            .Must(x => Enum.TryParse<Role>(x, out _))
            .WithMessage("Role is not valid");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match");

        RuleFor(x => x.EmailConfirmPagePath)
            .NotEmpty();

        RuleFor(x => x.ReturnUrl);
    }
}
