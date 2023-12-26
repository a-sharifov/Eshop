using Catalog.Domain.BrandAggregate;

namespace Catalog.Domain.Common;

public interface IRepository
{
    public void Add(Brand brand);
    public void Delete(Brand brand);
    public void Update(Brand brand);
}