namespace Catalog.Application.Sellers.Commands.CreateSeller;

public record CreateSellerCommand(
    string SellerName,
    string Email
    ) : ICommand;
