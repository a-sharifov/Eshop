using Catalog.Application.Services.Brands.Commands.CreateBrand;

namespace Catalog.Api.Controllers;

[Route("api/brands")]
public sealed class BrandsController(ISender sender) : ApiController(sender)
{
    [HttpPost]
    public async Task<IActionResult> CreateBrand(
        [FromBody] CreateBrandCommand createBrandCommand,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(createBrandCommand, cancellationToken);
        return result.IsSuccess ? Ok() : HandleFailure(result);
    }

}
