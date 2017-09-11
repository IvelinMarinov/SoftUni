public class Car
{
    public Car()
    {
        this.Weight = "n/a";
        this.Color = "n/a";
    }

    public Car(string model, Engine engine) : this()
    {
        this.Model = model;
        this.Engine = engine;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }
}