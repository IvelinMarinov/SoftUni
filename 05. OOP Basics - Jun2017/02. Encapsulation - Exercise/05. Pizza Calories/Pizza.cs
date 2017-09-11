using System;
using System.Collections.Generic;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    private int numberOfToppings;

    public Pizza()
    {
        this.toppings = new List<Topping>();
    }

    public Pizza(string name, int numberOfToppings)
    {
        this.Name = name;
        this.NumberOfToppings = numberOfToppings;
        this.toppings = new List<Topping>(numberOfToppings);
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

    public int NumberOfToppings
    {
        get { return this.numberOfToppings; }
        set
        {
            if (value < 0 || value > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.numberOfToppings = value;
        }
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
        this.toppings.Add(topping);
    }
}