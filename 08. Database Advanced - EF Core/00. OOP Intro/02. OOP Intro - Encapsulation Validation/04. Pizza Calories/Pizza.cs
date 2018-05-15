using System;
using System.Collections.Generic;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza()
    {
        this.toppings = new List<Topping>();
    }

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
    }
    
    public string Name
    {
        get { return this.name; }
        set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public Dough Dough
    {
        get { return this.dough; }
        set { this.dough = value; }
    }

    public List<Topping> Toppings
    {
        get { return this.toppings; }
        set { this.toppings = value; }
    }
    
    public double CalculateCalories()
    {
        var doughCalories = this.dough.CalculateCalories();
        double toppingsCalories = 0;

        foreach (var topping in this.toppings)
        {
            toppingsCalories += topping.CalculateCalories();
        }

        return doughCalories + toppingsCalories;
    }

    public void AddTopping(Topping topping)
    {
        if (this.toppings.Count >= 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

        this.toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.CalculateCalories():f2} Calories.";
    }
}