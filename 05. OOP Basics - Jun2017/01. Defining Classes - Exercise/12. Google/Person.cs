using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private Company company;
    private List<Pokemon> pokemons;
    private List<Parent> parents;
    private List<Child> children;
    private Car car;

    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Company Company
    {
        get { return this.company; }
        set { this.company = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public List<Parent> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }

    public List<Child> Children
    {
        get { return this.children; }
        set { this.children = value; }
    }

    public Car Car
    {
        get { return car; }
        set { car = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append($"{this.Name}" + Environment.NewLine);

        sb.Append("Company:" + Environment.NewLine);
        if (this.Company != null)
        {
            sb.Append($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:f2}" + Environment.NewLine);
        }

        sb.Append("Car:" + Environment.NewLine);
        if (this.Car != null)
        {
            sb.Append($"{this.Car.Model} {this.Car.Speed}" + Environment.NewLine);
        }

        sb.Append("Pokemon:" + Environment.NewLine);
        foreach (var pokemon in this.Pokemons)
        {
            sb.Append($"{pokemon.Name} {pokemon.Type}" + Environment.NewLine);
        }

        sb.Append("Parents:" + Environment.NewLine);
        foreach (var parent in this.Parents)
        {
            sb.Append($"{parent.Name} {parent.Birthday}" + Environment.NewLine);
        }

        sb.Append("Children:" + Environment.NewLine);
        foreach (var child in this.Children)
        {
            sb.Append($"{child.Name} {child.Birthday}" + Environment.NewLine);
        }

        return sb.ToString();
    }
}