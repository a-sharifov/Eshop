namespace Catalog.Presentation.Controllers.V1;

[Route("api/v{version:apiVersion}/products")]
[ApiVersion("1.0")]
public sealed class ProductsController(ISender sender) : ApiController(sender)
{

}
