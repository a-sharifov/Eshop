using Catalog.Domain.BrandAggregate;
using Catalog.Domain.BrandAggregate.ValueObjects;

namespace Catalog.Persistence.Configurations;

internal sealed class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable(nameof(Brand));
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasConversion(
            brandId => brandId.Value,
            value => new BrandId(value)).IsRequired();

        builder.Property(b => b.Name)
            .HasConversion(
            brandName => brandName.Value,
            value => BrandName.Create(value).Value
            )
            .HasMaxLength(BrandName.MaxLength)
            .IsRequired();

        builder.Property(b => b.Description)
               .HasConversion(
                brandDescription => brandDescription.Value,
                value => BrandDescription.Create(value).Value)
               .HasMaxLength(BrandDescription.MaxLength);

        builder.HasMany(b => b.Products)
               .WithOne(p => p.Brand)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
    }
}
