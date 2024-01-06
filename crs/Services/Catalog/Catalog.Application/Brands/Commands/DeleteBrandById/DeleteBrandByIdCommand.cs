namespace Catalog.Application.Brands.Commands.DeleteBrandById;

public sealed record DeleteBrandByIdCommand(Guid Id) : ICommand;
