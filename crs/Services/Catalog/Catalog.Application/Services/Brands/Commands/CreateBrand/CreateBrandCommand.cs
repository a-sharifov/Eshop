namespace Catalog.Application.Services.Brands.Commands.CreateBrand;

public sealed record CreateBrandCommand(string Name, string Description) : ICommand;
