using System;

public class Tomcat : Cat
{
    public Tomcat(string name, double age, string gender) : base(name, age, gender)
    {
        this.Gender = "Male";
    }

    public override string ProduceSound()
    {
        return "Give me one million b***h";
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Tomcat)}" + Environment.NewLine + $"{base.Name} {base.Age} {this.Gender}";
    }
}