using Catalog.Domain.Common.ValueObjects;
using Catalog.Domain.ProductAggregate;
using Catalog.Domain.SellerAggregate.Errors;
using Catalog.Domain.SellerAggregate.Ids;
using Catalog.Domain.SellerAggregate.ValueObjects;

namespace Catalog.Domain.SellerAggregate;

public sealed class Seller : AggregateRoot<SellerId>
{
    public SellerName SellerName { get; private set; }
    public Email Email { get; private set; }
    public List<Product> Products { get; private set; }

    private Seller()
    {
    }

    private Seller(
        SellerId id,
        SellerName sellerName,
        Email email,
        List<Product> products)
        : base(id)
    {
        SellerName = sellerName;
        Email = email;
        Products = products;
    }

    public static Result<Seller> Create(
        SellerId id,
        SellerName sellerName,
        Email email,
        List<Product> products,
        bool isSellerNameUnique)
    {
        if (!isSellerNameUnique)
        {
            return Result.Failure<Seller>(
                SellerErrors.SellerNameIsNotUnique(sellerName.Value));
        }

        var seller = new Seller(id, sellerName, email, products);

        seller.AddDomainEvent(
            new SellerCreatedDomainEvent(Guid.NewGuid(), id));

        return seller;
    }
}
