using System;

public class Cat : Animal
{
    public Cat(string name, double age, string gender) 
        : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "Meow meow";
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Cat)}" + Environment.NewLine + $"{base.Name} {base.Age} {base.Gender}";
    }
}