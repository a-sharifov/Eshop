namespace Catalog.Presentation.V1.Controllers;

[Route("api/v{version:apiVersion}/categories")]
[ApiVersion("1.0")]
public sealed class CategoriesController(ISender sender) : ApiController(sender)
{
}
