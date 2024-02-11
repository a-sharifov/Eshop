using Catalog.Application.Sellers.Commands.CreateSeller;

namespace Catalog.Application.Sellers.Commands.AddSeller;

internal sealed class AddSellerCommandHandler(
    ISender sender, 
    IIdentityGrpcService identityGrpcService) 
    : ICommandHandler<AddSellerCommand>
{
    private readonly ISender _sender = sender;
    private readonly IIdentityGrpcService _identityGrpcService = identityGrpcService;

    public async Task<Result> Handle(AddSellerCommand request, CancellationToken cancellationToken)
    {
        var userInfo = await _identityGrpcService.GetUserInfoAsync(request.UserId);

        var command = new CreateSellerCommand(userInfo.Email, userInfo.Email);
        return await _sender.Send(command);
    }
}
