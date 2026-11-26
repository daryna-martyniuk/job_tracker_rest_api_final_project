using Domain.Companies;

namespace Domain.Applications;

public class JobApplication
{
    public JobApplicationId Id { get; }
    public CompanyId CompanyId { get; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public ApplicationStatus Status { get; private set; }
    public WorkFormat? WorkFormat { get; private set; }
    public EmploymentType? EmploymentType { get; private set; }
    public DateOnly AppliedAt { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; private set; }
    public ApplicationAttributes Attributes { get; private set; } = ApplicationAttributes.Empty();
    public Company? Company { get; } = null;
    
    private  JobApplication(
        JobApplicationId id,
        CompanyId companyId,
        string title,
        string? description,
        ApplicationStatus status,
        WorkFormat? workFormat,
        EmploymentType? employmentType,
        DateOnly appliedAt,
        DateTime createdAt)
    {
        Id = id;
        CompanyId = companyId;
        Title = title;
        Description = description;
        Status = status;
        WorkFormat = workFormat;
        EmploymentType = employmentType;
        AppliedAt = appliedAt;
        CreatedAt = createdAt;
    }

    public static JobApplication New(
        JobApplicationId id,
        CompanyId companyId,
        string title,
        string? description,
        ApplicationStatus status,
        WorkFormat? workFormat,
        EmploymentType? employmentType,
        DateOnly appliedAt,
        DateTime createdAt,
        ApplicationAttributes? attributes
    )
    {
        var application = new JobApplication(
            id,
            companyId,
            title,
            description,
            ApplicationStatus.Applied,
            workFormat,
            employmentType,
            appliedAt,
            DateTime.UtcNow);

        application.Attributes = attributes ?? ApplicationAttributes.Empty();

        return application;
    }

    public void UpdateDetails(
        string title,
        string? description,
        WorkFormat? workFormat,
        EmploymentType? employmentType,
        ApplicationAttributes? attributes
    )
    {
        Title = title;
        Description = description;
        WorkFormat = workFormat;
        EmploymentType = employmentType;
        Attributes = attributes ?? ApplicationAttributes.Empty();
        UpdatedAt = DateTime.UtcNow;
    }
}
    