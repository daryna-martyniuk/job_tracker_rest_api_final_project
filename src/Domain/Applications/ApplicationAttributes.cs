namespace Domain.Applications;

public class ApplicationAttributes
{
    public int? SalaryMin { get; }
    public int? SalaryMax { get; }
    public Currency? Currency { get; }
    public string? Location { get; }
    public string? Source { get; }
    public string? VacancyUrl { get; }
    public int? Priority { get; }
    public DateOnly? ResponseDeadline { get; }
    
    private ApplicationAttributes(
        int? salaryMin,
        int? salaryMax,
        Currency? currency,
        string? location,
        string? source,
        string? vacancyUrl,
        int? priority,
        DateOnly? responseDeadline)
    {
        SalaryMin = salaryMin;
        SalaryMax = salaryMax;
        Currency = currency;
        Location = location;
        Source = source;
        VacancyUrl = vacancyUrl;
        Priority = priority;
        ResponseDeadline = responseDeadline;
    }

    public static ApplicationAttributes New(
        int? salaryMin,
        int? salaryMax,
        Currency? currency,
        string? location,
        string? source,
        string? vacancyUrl,
        int? priority,
        DateOnly? responseDeadline)
    {
        return new ApplicationAttributes(
            salaryMin,
            salaryMax,
            currency,
            location,
            source,
            vacancyUrl,
            priority,
            responseDeadline);
    }

    public static ApplicationAttributes Empty() 
        => new(null, null, null, null, null, null, null, null);
}