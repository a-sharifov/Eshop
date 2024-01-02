using Catalog.Application.Brands.Commands.CreateBrand;

namespace Catalog.Presentation.Controllers.V1;

[Route("api/v{version:apiVersion}/brands")]
[ApiVersion("1.0")]
public sealed class BrandsController(ISender sender) : ApiController(sender)
{
    [HttpPost]
    public async Task<IActionResult> CreateBrand(
        [FromBody] CreateBrandCommand createBrandCommand,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(createBrandCommand, cancellationToken);
        return result.IsSuccess ? Ok()
            : HandleFailure(result);
    }

}
