namespace Catalog.Api.Controllers;

[Route("api/products")]
public sealed class ProductsController(ISender sender) : ApiController(sender)
{

}
