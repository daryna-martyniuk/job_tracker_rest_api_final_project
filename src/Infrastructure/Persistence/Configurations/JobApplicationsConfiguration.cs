using Domain.Applications;
using Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class JobApplicationsConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new JobApplicationId(x))
            .ValueGeneratedNever();
        
        builder.Property(x => x.CompanyId)
            .HasConversion(x => x.Value, x => new CompanyId(x))
            .IsRequired();
        
        builder.HasOne(x => x.Company)
            .WithMany()
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict); // видалення компанії, в якої є заявки, заборонене
        builder.Property(x => x.Title)
            .HasColumnType("Varchar(255)")
            .IsRequired();
        builder.HasIndex(x => x.Title).IsUnique();
        
        builder.Property(x => x.Description)
            .HasColumnType("Varchar(500)");
        
        builder.Property(x => x.Status)
            .HasColumnType("Varchar(32)")
            .HasConversion<string>()
            .IsRequired();
        builder.Property(x => x.WorkFormat)
            .HasColumnType("varchar(32)")
            .HasConversion<string>();

        builder.Property(x => x.EmploymentType)
            .HasColumnType("varchar(32)")
            .HasConversion<string>();
        
        builder.Property(x => x.AppliedAt).IsRequired();
        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
        builder.Property(x => x.UpdatedAt);

        builder.OwnsOne(x => x.Attributes, atributesBuilder =>
        {
            atributesBuilder.ToJson("attributes");
            atributesBuilder.Property(x => x.SalaryMin).HasJsonPropertyName("salary_min");
            atributesBuilder.Property(x => x.SalaryMax).HasJsonPropertyName("salary_max");
            atributesBuilder.Property(x => x.Currency).HasJsonPropertyName("currency");
            atributesBuilder.Property(x => x.Location).HasJsonPropertyName("location");
            atributesBuilder.Property(x => x.Source).HasJsonPropertyName("source");
            atributesBuilder.Property(x => x.VacancyUrl).HasJsonPropertyName("vacancy_url");
            atributesBuilder.Property(x => x.Priority).HasJsonPropertyName("priority");
            atributesBuilder.Property(x => x.ResponseDeadline).HasJsonPropertyName("response_deadline");
        });
        builder.Navigation(x => x.Attributes).IsRequired();
    }
}