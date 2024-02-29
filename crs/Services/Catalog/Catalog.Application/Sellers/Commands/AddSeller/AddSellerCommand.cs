namespace Catalog.Application.Sellers.Commands.AddSeller;

public sealed record AddSellerCommand(Guid UserId) : ICommand;
