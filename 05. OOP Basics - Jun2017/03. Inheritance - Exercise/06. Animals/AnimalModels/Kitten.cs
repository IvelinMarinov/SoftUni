using System;

public class Kitten : Cat
{
    public Kitten(string name, double age, string gender) : base(name, age, gender)
    {
        this.Gender = "Female";
    }

    public override string ProduceSound()
    {
        return "Miau";
    }


    public override string IntroduceAnimal()
    {
        return $"{typeof(Kitten)}" + Environment.NewLine + $"{base.Name} {base.Age} {this.Gender}";
    }
}