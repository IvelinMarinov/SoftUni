public class StreetExtraordinaire : Cat
{
    private double decibelsOfMeows;

    public StreetExtraordinaire(string name, double decibelsOfMeows)
    {
        this.Name = name;
        this.DecibelsOfMeows = decibelsOfMeows;
    }

    public double DecibelsOfMeows
    {
        get { return decibelsOfMeows; }
        set { decibelsOfMeows = value; }
    }

    public override string ToString()
    {
        return $"StreetExtraordinaire {this.Name} {this.DecibelsOfMeows}";
    }
}