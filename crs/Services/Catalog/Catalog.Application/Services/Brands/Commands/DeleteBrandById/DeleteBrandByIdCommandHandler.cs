namespace Catalog.Application.Services.Brands.Commands.DeleteBrandById;

internal sealed class DeleteBrandByIdCommandHandler(
    IBrandRepository brandRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteBrandByIdCommand>
{
    private readonly IBrandRepository _brandRepository = brandRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteBrandByIdCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(
            request.Id);

        var brandId = new BrandId(id);

        await _brandRepository.DeleteByIdAsync(brandId, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
