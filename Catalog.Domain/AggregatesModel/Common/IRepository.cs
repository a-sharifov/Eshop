namespace Catalog.Domain.AggregatesModel.Common;

public interface IRepository
{
    public void Add(Brand brand);
    public void Delete(Brand brand);
    public void Update(Brand brand);
}