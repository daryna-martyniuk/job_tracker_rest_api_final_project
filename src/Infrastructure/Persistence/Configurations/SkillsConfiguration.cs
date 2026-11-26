using Domain.Skills;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SkillsConfiguration :  IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new SkillId(x))
            .ValueGeneratedNever();
        
        builder.Property(s => s.Name)
            .HasColumnType("varchar(255)")
            .IsRequired();
        builder.HasIndex(s => s.Name).IsUnique();
        
        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
    }
}