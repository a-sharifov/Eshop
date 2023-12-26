using Catalog.Domain.CategoryAggregate;
using Catalog.Domain.CategoryAggregate.ValueObjects;

namespace Catalog.Persistence.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category));
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
             categoryId => categoryId.Value,
             value => new CategoryId(value)).IsRequired();

        builder.Property(c => c.Name)
            .HasConversion(
            categoryName => categoryName.Value,
            value => CategoryName.Create(value).Value
            )
               .IsRequired();

        builder.HasMany(c => c.Products)
               .WithOne(p => p.Category)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
    }
}
