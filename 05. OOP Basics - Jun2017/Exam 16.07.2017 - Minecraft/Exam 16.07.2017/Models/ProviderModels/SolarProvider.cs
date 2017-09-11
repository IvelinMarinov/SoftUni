using System.Text;

public class SolarProvider : Provider
{
    public SolarProvider(string id, double eneryOutput)
        : base(id, eneryOutput)
    {

    }

    public override string Print()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Solar Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.EnergyOutput}");

        return sb.ToString().Trim();
    }
}