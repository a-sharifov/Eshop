namespace Catalog.Api.Controllers;

[Route("api/categories")]
public sealed class CategoriesController(ISender sender) : ApiController(sender)
{
}
