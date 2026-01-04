namespace CsharpLearn.Domain.Entities;

public class Skill
{
    public string Name { get; set; }
    
    public int Cooldown { get; set; }
    
    private Skill(){}
}