namespace Catalog.Presentation.V1.Models;

public sealed record CreateBrandRequest(
    [Required] string Name,
    [Required] string Description);
