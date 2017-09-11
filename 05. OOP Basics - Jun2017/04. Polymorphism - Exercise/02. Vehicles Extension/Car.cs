using System;

public class Car : Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionLtsPerKm;
    private double tankCapacity;
    
    public Car(double fuelQuantity, double fuelConsumptionLtsPerKm, double tankCapacity) 
        :base(fuelQuantity, fuelConsumptionLtsPerKm, tankCapacity)
    {
        this.FuelConsumptionLtsPerKm = fuelConsumptionLtsPerKm;
    }
    
    public double FuelConsumptionLtsPerKm
    {
        get { return this.fuelConsumptionLtsPerKm; }
        set { this.fuelConsumptionLtsPerKm = value + 0.9; }
    }

    public override string Drive(double distance)
    {
        if (distance * this.FuelConsumptionLtsPerKm > this.FuelQuantity)
        {
            return "Car needs refueling";
        }
        else
        {
            this.FuelQuantity -= distance * this.FuelConsumptionLtsPerKm;
            return $"Car travelled {distance} km";
        }
    }

    public override void Refuel(double fuelAdded)
    {
        if (fuelAdded <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (fuelAdded > this.TankCapacity - this.FuelQuantity)
        {
            throw new ArgumentException("Cannot fit fuel in tank");
        }
        this.FuelQuantity += fuelAdded;
    }

    public override string ToString()
    {
        return $"Car: {this.FuelQuantity:f2}";
    }
}