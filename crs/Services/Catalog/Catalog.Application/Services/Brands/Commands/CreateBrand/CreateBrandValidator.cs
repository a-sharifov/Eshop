namespace Catalog.Application.Services.Brands.Commands.CreateBrand;

internal sealed class CreateBrandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(BrandName.MaxLength);

        RuleFor(x => x.Description)
            .MaximumLength(BrandDescription.MaxLength);
    }
}
