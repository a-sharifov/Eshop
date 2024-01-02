namespace Catalog.Presentation.Controllers.V1;

[Route("api/v{version:apiVersion}/sellers")]
[ApiVersion("1.0")]
public sealed class SellersController(ISender sender) : ApiController(sender)
{

}
