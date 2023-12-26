namespace Catalog.Persistence.Configurations;

internal sealed class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.ToTable(nameof(Seller));
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasConversion(
            sellerId => sellerId.Value,
            value => new SellerId(value)).IsRequired();

        builder.Property(s => s.SellerName)
            .HasConversion(
            sellerName => sellerName.Value,
            value => SellerName.Create(value).Value
            )
               .HasMaxLength(SellerName.MaxLength)
               .IsRequired();

        builder.Property(s => s.Email).HasConversion(
                email => email.Value,
                email => Email.Create(email).Value).IsRequired();

        builder.HasMany(s => s.Products)
               .WithOne(p => p.Seller)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
    }
}
