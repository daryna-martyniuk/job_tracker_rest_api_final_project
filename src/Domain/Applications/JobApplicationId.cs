namespace Domain.Applications;

public record JobApplicationId(Guid Value)
{
    public static JobApplicationId New() => new(Guid.NewGuid());
    public static JobApplicationId Empty() => new(Guid.Empty);
    public override string ToString() => Value.ToString();
}