using System;

public class Frog : Animal
{
    public Frog(string name, double age, string gender) 
        : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "Ribbit";
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Frog)}" + Environment.NewLine + $"{base.Name} {base.Age} {base.Gender}";
    }
}