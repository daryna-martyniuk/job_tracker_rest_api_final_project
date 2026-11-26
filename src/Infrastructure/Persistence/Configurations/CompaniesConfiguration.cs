using Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CompaniesConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new CompanyId(x))
            .ValueGeneratedNever();
        
        builder.Property(x => x.Name)
            .HasColumnType("varchar(255)")
            .IsRequired();
        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.Website)
            .HasColumnType("varchar(500)");
        builder.Property(x => x.Notes)
            .HasColumnType("text");
        
        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
        builder.Property(x => x.UpdatedAt);
    }
}