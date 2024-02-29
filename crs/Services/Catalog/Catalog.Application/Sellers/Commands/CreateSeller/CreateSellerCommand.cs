namespace Catalog.Application.Sellers.Commands.CreateSeller;

public sealed record CreateSellerCommand(
    string SellerName,
    string Email
    ) : ICommand;
