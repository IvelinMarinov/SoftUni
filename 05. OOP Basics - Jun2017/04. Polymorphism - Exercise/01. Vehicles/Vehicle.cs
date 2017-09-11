public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionLtsPerKm;
    
    public Vehicle(double fuelQuantity, double fuelConsumptionLtsPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionLtsPerKm = fuelConsumptionLtsPerKm;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set { this.fuelQuantity = value; }
    }

    public double FuelConsumptionLtsPerKm
    {
        get { return this.fuelConsumptionLtsPerKm; }
        set { this.fuelConsumptionLtsPerKm = value; }
    }
    
    public abstract string Drive(double distance);

    public abstract void Refuel(double fuelAdded);
}

