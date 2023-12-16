namespace Catalog.Domain.AggregatesModel.SellerAggregate;

public sealed class Seller : AggregateRoot<SellerId>
{
    public SellerName SellerName { get; private set; }
    public Email Email { get; private set; }
    public List<Product> Products { get; private set; }

    private Seller()
    {
    }

    public Seller(
        SellerId id, 
        SellerName sellerName, 
        Email email, 
        List<Product> products) 
        : base(id)
    {
        SellerName = sellerName;
        Email = email;
        Products = products;

        AddDomainEvent(
            new SellerCreatedDomainEvent(Guid.NewGuid(), id));
    }

}