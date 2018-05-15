using System;

public class Dog : Animal
{
    public Dog(string name, double age, string gender) 
        : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Dog)}" + Environment.NewLine + $"{base.Name} {base.Age} {base.Gender}";
    }
}