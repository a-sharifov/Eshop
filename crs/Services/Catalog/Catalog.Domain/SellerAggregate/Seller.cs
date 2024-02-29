namespace Catalog.Domain.SellerAggregate;

public sealed class Seller : AggregateRoot<SellerId>
{
    public SellerName SellerName { get; private set; }
    public Email Email { get; private set; }
    public List<Product> Products { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Seller() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
        bool isSellerNameExist)
    {
        if (isSellerNameExist)
        {
            return Result.Failure<Seller>(
                SellerErrors.SellerNameIsNotUnique(sellerName.Value));
        }

        var seller = new Seller(id, sellerName, email, products: []);

        seller.AddDomainEvent(
            new SellerCreatedDomainEvent(Guid.NewGuid(), id));

        return seller;
    }
}
