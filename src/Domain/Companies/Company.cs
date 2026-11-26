namespace Domain.Companies;

public class Company
{
    public CompanyId Id { get; }
    public string Name { get; private set; }
    public string? Website { get; private set; }
    public string? Notes { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; private set; }

    private Company(CompanyId id, string name, string? website, string? notes,  DateTime createdAt)
    {
        Id = id;
        Name = name;
        Website = website;
        Notes = notes;
        CreatedAt = createdAt;
    }

    public static Company New(CompanyId id, string name, string? website, string? notes)
    {
        return new Company(id, name, website, notes, DateTime.UtcNow);
    }

    public void UpdateDetasls(string name, string? website, string? notes)
    {
        Name = name;
        Website = website;
        Notes = notes;
        UpdatedAt = DateTime.UtcNow;
    }
}