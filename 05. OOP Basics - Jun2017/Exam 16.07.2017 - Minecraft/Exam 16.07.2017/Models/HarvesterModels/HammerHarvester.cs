using System;
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *= 3;
        this.EnergyRequirement *= 2;
    }

    public override string Print()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Hammer Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {OreOutput}");
        sb.AppendLine($"Energy Requirement: { this.EnergyRequirement}");
        
        return sb.ToString().Trim();
    }
}