namespace Identity.Persistence.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
            userId => userId.Value,
            value => new UserId(value)).IsRequired();

        builder.Property(x => x.Email).HasConversion(
            email => email.Value,
            value => Email.Create(value).Value)
            .HasMaxLength(Email.EmailMaxLength)
            .IsRequired();

        builder.Property(x => x.PasswordHash).HasConversion(
            password => password.Value,
            value => PasswordHash.Create(value).Value)
            .HasMaxLength(PasswordHash.MaxLength)
            .IsRequired();

        builder.Property(x => x.FirstName).HasConversion(
            firstName => firstName.Value,
            value => FirstName.Create(value).Value)
            .HasMaxLength(FirstName.MaxLength)
            .IsRequired();

        builder.Property(x => x.LastName).HasConversion(
            lastName => lastName.Value,
            value => LastName.Create(value).Value)
            .HasMaxLength(LastName.MaxLength)
            .IsRequired();

        builder.Property(x => x.Role).IsRequired();
    }
}
