public class Engine
{
    public Engine()
    {
        this.Displacement = "n/a";
        this.Efficiency = "n/a";
    }

    public Engine(string model, int power) : this()
    {
        this.Model = model;
        this.Power = power;
    }

    public string Model { get; set; }
    public int Power { get; set; }
    public string Displacement { get; set; }
    public string Efficiency { get; set; }
}