namespace Catalog.Persistence.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value,
            value => new ProductId(value)).IsRequired();

        builder.Property(p => p.Sku).HasConversion(
            sku => sku.Value,
            value => Sku.Create(value).Value).IsRequired();

        builder.Property(p => p.ProductImage).HasConversion(
            imageUrl => imageUrl.Value,
            value => ImageUrl.Create(value).Value).IsRequired();

        //It is possible to create a separate configuration file for the price
        builder.OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency)
            .IsRequired();

            priceBuilder.Property(m => m.Amount)
            .HasColumnType("decimal(18,2)").IsRequired();
        });

        builder.Property(p => p.Description)
            .HasConversion(
            productDescription => productDescription.Value,
            value => ProductDescription.Create(value).Value
            )
            .HasMaxLength(ProductDescription.MaxLength);

        builder.Property(p => p.Name)
            .HasConversion(
            productName => productName.Value,
            value => ProductName.Create(value).Value
            )
            .HasMaxLength(ProductName.ProductNameMaxLength)
            .IsRequired();

        builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

        builder.HasOne(p => p.Seller)
               .WithMany(s => s.Products)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

        builder.HasOne(p => p.Brand)
               .WithMany(b => b.Products)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
    }
}
