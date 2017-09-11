using System;

public class Bus : Vehicle
{
    private double fuelConsumptionLtsPerKm;

    public Bus(double fuelQuantity, double fuelConsumptionLtsPerKm, double tankCapacity)
        :base(fuelQuantity, fuelConsumptionLtsPerKm, tankCapacity)
    {
        this.FuelConsumptionLtsPerKm = fuelConsumptionLtsPerKm;
    }
    
    public double FuelConsumptionLtsPerKm
    {
        get { return this.fuelConsumptionLtsPerKm; }
        set { this.fuelConsumptionLtsPerKm = value + 1.4; }
    }
    
    public override string Drive(double distance)
    {
        if (distance * this.FuelConsumptionLtsPerKm > this.FuelQuantity)
        {
            return "Bus needs refueling";
        }
        else
        {
            this.FuelQuantity -= distance * this.FuelConsumptionLtsPerKm;
            return $"Bus travelled {distance} km";
        }
    }

    public string DriveEmpty(double distance)
    {
        var fuelConsumptionWhenEmpty = this.FuelConsumptionLtsPerKm - 1.4;

        if (distance * fuelConsumptionWhenEmpty > this.FuelQuantity)
        {
            return "Bus needs refueling";
        }
        else
        {
            this.FuelQuantity -= distance * fuelConsumptionWhenEmpty;
            return $"Bus travelled {distance} km";
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
        return $"Bus: {this.FuelQuantity:f2}";
    }
}