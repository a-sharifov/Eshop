using Catalog.Application.Brands.Commands.CreateBrand;
using Catalog.Presentation.V1.Models;

namespace Catalog.Presentation.V1.Controllers;

[Route("api/v{version:apiVersion}/brands")]
[ApiVersion("1.0")]
public sealed class BrandsController(ISender sender) : ApiController(sender)
{
    [HttpPost("create-brand")]
    public async Task<IActionResult> CreateBrand(
        [FromBody] CreateBrandRequest request,
        CancellationToken cancellationToken)
    {
        var createBrandCommand =
            new CreateBrandCommand(request.Name, request.Description);

        var result = await _sender.Send(createBrandCommand, cancellationToken);
        return result.IsSuccess ? Ok()
            : HandleFailure(result);
    }

}
