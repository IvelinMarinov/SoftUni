using System;

public class Car : Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionLtsPerKm;

    public Car(double fuelQuantity, double fuelConsumptionLtsPerKm)
        :base(fuelQuantity, fuelConsumptionLtsPerKm)
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
        this.FuelQuantity += fuelAdded;
    }

    public override string ToString()
    {
        return $"Car: {this.FuelQuantity:f2}";
    }
}