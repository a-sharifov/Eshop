namespace Catalog.Presentation.V1.Controllers;

//[Route("api/v{version:apiVersion}/products")]
//[ApiVersion("1.0")]
public sealed class ProductsController(ISender sender) : ApiController(sender)
{

}
