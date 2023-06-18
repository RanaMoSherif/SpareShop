namespace BestAuto.Domain.Entities;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .Property(b => b.Name)
            .HasMaxLength(400)
            .IsRequired();
    }
}