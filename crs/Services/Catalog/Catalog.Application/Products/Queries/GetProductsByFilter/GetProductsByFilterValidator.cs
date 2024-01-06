namespace Catalog.Application.Products.Queries.GetProductsByFilter;

internal sealed class GetProductsByFilterValidator : AbstractValidator<GetProductsByFilterQuerie>
{

    public GetProductsByFilterValidator()
    {
        //RuleFor(x => x.Skip)
        //    .GreaterThanOrEqualTo(0);

        //RuleFor(x => x.Take)
        //    .GreaterThanOrEqualTo(0);

        //RuleFor(x => x.Sku)
        //    .MaximumLength(Sku.MaxLength);

        //RuleFor(x => x.Name)
        //    .MaximumLength(ProductName.ProductNameMaxLength);

        //RuleFor(x => x.PriceFrom)
        //    .GreaterThanOrEqualTo(0);

        //RuleFor(x => x.PriceTo)
        //    .GreaterThanOrEqualTo(0);

        //RuleFor(x => x.CategoryId)
        //    .MustAsync(async (id, cancellationToken) => await categoryRepository.ExistsAsync(id, cancellationToken))
        //    .When(x => x.CategoryId.HasValue)
        //    .WithMessage("Category does not exist");

        //RuleFor(x => x.SellerId)
        //    .MustAsync(async (id, cancellationToken) => await sellerRepository.ExistsAsync(id, cancellationToken))
        //    .When(x => x.SellerId.HasValue)
        //    .WithMessage("Seller does not exist");

        //RuleFor(x => x.BrandId)
        //    .MustAsync(async (id, cancellationToken) => await brandRepository.ExistsAsync(id, cancellationToken))
        //    .When(x => x.BrandId.HasValue)
        //    .WithMessage("Brand does not exist");
    }
}
