namespace Domain.Skills;

public class Skill
{
    public SkillId Id { get; }
    public string Name { get; }
    public DateTime CreatedAt { get; }

    private Skill(SkillId id, string name, DateTime createdAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
    }

    public static Skill New(SkillId id, string name)
    {
        return new Skill(id, name, DateTime.UtcNow);
    }
    
}