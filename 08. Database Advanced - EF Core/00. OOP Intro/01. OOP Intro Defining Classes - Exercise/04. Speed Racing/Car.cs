public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionPerKm;
    private double distanceTravelled;

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionPerKm = fuelConsumption;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        set { this.fuelConsumptionPerKm = value; }
    }

    public double DistanceTravelled
    {
        get { return this.distanceTravelled; }
        set { this.distanceTravelled = value; }
    }

    public bool Travel(double distance)
    {
        if (distance > FuelAmount / FuelConsumptionPerKm)
        {
            return false;
        }
        else
        {
            this.FuelAmount -= FuelConsumptionPerKm * distance;
            this.DistanceTravelled += distance;
            return true;
        }
    }
}