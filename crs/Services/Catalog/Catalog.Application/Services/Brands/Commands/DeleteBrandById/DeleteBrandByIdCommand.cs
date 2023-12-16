namespace Catalog.Application.Services.Brands.Commands.DeleteBrandById;

public sealed record DeleteBrandByIdCommand(string Id) : ICommand;
