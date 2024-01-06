namespace Catalog.Application.Brands.Commands.CreateBrand;

public sealed record CreateBrandCommand(string Name, string Description) : ICommand;
