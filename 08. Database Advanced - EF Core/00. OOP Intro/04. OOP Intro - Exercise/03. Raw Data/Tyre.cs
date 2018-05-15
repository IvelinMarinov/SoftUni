public class Tyre
{
    private double pressure;
    private int age;

    public Tyre(double pressure, int age)
    {
        this.Pressure = pressure;
        this.Age = age;
    }
    public double Pressure
    {
        get { return this.pressure; }
        set { this.pressure = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
}