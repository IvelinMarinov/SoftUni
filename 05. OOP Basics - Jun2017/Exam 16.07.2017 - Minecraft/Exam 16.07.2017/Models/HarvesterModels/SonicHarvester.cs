using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement /= sonicFactor;
        this.SonicFactor = sonicFactor;
    }

    public int SonicFactor
    {
        get { return this.sonicFactor; }
        protected set { this.sonicFactor = value; }
    }

    public override string Print()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Sonic Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {OreOutput}");
        sb.AppendLine($"Energy Requirement: { this.EnergyRequirement}");

        return sb.ToString().Trim();
    }
}