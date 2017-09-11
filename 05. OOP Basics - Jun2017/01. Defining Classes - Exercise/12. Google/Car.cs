public class Car
{
    private string model;
    private double speed;

    public Car(string model, double speed)
    {
        this.Model = model;
        this.Speed = speed;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public double Speed
    {
        get { return this.speed; }
        set { this.speed = value; }
    }
}