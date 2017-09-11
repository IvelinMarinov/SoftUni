using System;

public class Truck : Vehicle
{
    private double fuelConsumptionLtsPerKm;

    public Truck(double fuelQuantity, double fuelConsumptionLtsPerKm, double tankCapacity) 
        :base(fuelQuantity, fuelConsumptionLtsPerKm, tankCapacity)
    {
        this.FuelConsumptionLtsPerKm = fuelConsumptionLtsPerKm;
    }
    
    public double FuelConsumptionLtsPerKm
    {
        get { return this.fuelConsumptionLtsPerKm; }
        set { this.fuelConsumptionLtsPerKm = value + 1.6; }
    }
    
    public override string Drive(double distance)
    {
        if (distance * this.FuelConsumptionLtsPerKm > this.FuelQuantity)
        {
            return "Truck needs refueling";
        }
        else
        {
            this.FuelQuantity -= distance * this.FuelConsumptionLtsPerKm;
            return $"Truck travelled {distance} km";
        }
    }

    public override void Refuel(double fuelAdded)
    {
        if (fuelAdded <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        this.FuelQuantity += fuelAdded * 0.95;
    }

    public override string ToString()
    {
        return $"Truck: {this.FuelQuantity:f2}";
    }
}