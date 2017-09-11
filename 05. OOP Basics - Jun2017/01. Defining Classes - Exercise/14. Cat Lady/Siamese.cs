public class Siamese : Cat
{
    private double earSize;

    public Siamese(string name, double earSize)
    {
        this.Name = name;
        this.EarSize = earSize;
    }

    public double EarSize
    {
        get { return earSize; }
        set { earSize = value; }
    }

    public override string ToString()
    {
        return $"Siamese {this.Name} {this.EarSize}";
    }
}