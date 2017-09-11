using System;
using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double eneryOutput)
        : base(id, eneryOutput)
    {
        this.EnergyOutput += this.EnergyOutput * 50 / 100;
    }

    public override string Print()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Pressure Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.EnergyOutput}");

        return sb.ToString().Trim();
    }
}