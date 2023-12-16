namespace Catalog.Api.Controllers;

[Route("api/sellers")]
public sealed class SellersController(ISender sender) : ApiController(sender)
{

}
