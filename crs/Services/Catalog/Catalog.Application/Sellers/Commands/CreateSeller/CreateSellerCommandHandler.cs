using Catalog.Domain.Common.ValueObjects;
using Catalog.Domain.SellerAggregate.Ids;
using Catalog.Domain.SellerAggregate.ValueObjects;

namespace Catalog.Application.Sellers.Commands.CreateSeller;

internal sealed class CreateSellerCommandHandler(
    ISellerRepository sellerRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateSellerCommand>
{
    private readonly ISellerRepository _sellerRepository = sellerRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
    {
        var sellerId = new SellerId(Guid.NewGuid());
        var sellerNameResult = SellerName.Create(request.SellerName);
        var emailResult = Email.Create(request.Email);
        var isSellerNameExist = await _sellerRepository.IsSellerNameExist(sellerNameResult.Value, cancellationToken);

        var sellerResult = Seller.Create(
            sellerId,
            sellerNameResult.Value,
            emailResult.Value,
            isSellerNameExist
            );

        if (sellerResult.IsFailure)
        {
            return Result.Failure(sellerResult.Error);
        }

        await _sellerRepository.AddAsync(sellerResult.Value, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
