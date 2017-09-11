public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionLtsPerKm;
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumptionLtsPerKm, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionLtsPerKm = fuelConsumptionLtsPerKm;
        this.TankCapacity = tankCapacity;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set { this.fuelQuantity = value; }
    }

    public double FuelConsumptionLtsPerKm
    {
        get { return this.fuelConsumptionLtsPerKm; }
        set { this.fuelConsumptionLtsPerKm = value ; }
    }

    public double TankCapacity
    {
        get { return this.tankCapacity; }
        set { this.tankCapacity = value; }
    }

    public abstract string Drive(double distance);

    public abstract void Refuel(double fuelAdded);
}

