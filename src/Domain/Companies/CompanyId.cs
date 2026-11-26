namespace Domain.Companies;

public record CompanyId(Guid Value)
{
    public static CompanyId New() => new(Guid.NewGuid());
    public static CompanyId Empty() => new(Guid.Empty);
    public override string ToString() => Value.ToString();
}