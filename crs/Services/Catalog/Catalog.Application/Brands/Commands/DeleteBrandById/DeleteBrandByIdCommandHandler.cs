namespace Catalog.Application.Brands.Commands.DeleteBrandById;

internal sealed class DeleteBrandByIdCommandHandler(
    IBrandRepository brandRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteBrandByIdCommand>
{
    private readonly IBrandRepository _brandRepository = brandRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteBrandByIdCommand request, CancellationToken cancellationToken)
    {
        var brandId = new BrandId(request.Id);

        await _brandRepository.DeleteByIdAsync(brandId, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}
