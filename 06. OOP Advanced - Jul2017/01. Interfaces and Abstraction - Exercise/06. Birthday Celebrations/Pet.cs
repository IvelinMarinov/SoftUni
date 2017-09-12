using System;

public class Pet : ISubject, ISubjectWithBirthdate
{
    public Pet(string name, DateTime birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }

    public string Name { get; set; }

    public DateTime Birthdate { get; set; }
}