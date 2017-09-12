using System;

public class Citizen : IBuyer
{
    public Citizen(string name, int age, string id, DateTime birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }
    
    public string Name { get; set; }

    public int Age { get; set; }

    public string Id { get; set; }

    public DateTime Birthdate { get; set; }

    public int Food { get; set; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}