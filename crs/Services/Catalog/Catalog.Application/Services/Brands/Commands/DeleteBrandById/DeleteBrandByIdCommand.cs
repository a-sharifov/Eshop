namespace Catalog.Application.Services.Brands.Commands.DeleteBrandById;

public sealed record DeleteBrandByIdCommand(Guid Id) : ICommand;
