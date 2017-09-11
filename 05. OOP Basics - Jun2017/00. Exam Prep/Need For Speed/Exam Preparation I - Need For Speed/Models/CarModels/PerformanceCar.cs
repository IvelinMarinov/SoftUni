using System;
using System.Collections.Generic;

public class PerformanceCar : Car
{
    private int horsepower;
    private int suspension;

    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        base.Horsepower += base.Horsepower * 50 / 100;
        base.Suspension = base.Suspension * 75 / 100;
        this.AddOns = new List<string>();
    }

    public List<string> AddOns
    {
        get { return this.addOns; }
        set { this.addOns = value; }
    }

    public int Horsepower
    {
        get { return this.horsepower; }
        set { this.horsepower = value; }
    }

    public int Suspension
    {
        get { return this.suspension; }
        set { this.suspension = value; }
    }

    public override string ToString()
    {
        if (this.AddOns.Count > 0)
        {
            return base.ToString() + $"Add-ons: {string.Join(", ", AddOns)}";
        }
        else
        {
            return base.ToString() + $"Add-ons: None";
        }
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.addOns.Add(addOn);
    }
}