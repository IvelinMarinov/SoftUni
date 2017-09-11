using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester Create(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequrement = double.Parse(arguments[3]);

        if (type.ToLower() == "sonic")
        {
            var sonicFactor = int.Parse(arguments[4]);
            return new SonicHarvester(id, oreOutput, energyRequrement, sonicFactor);
        }
        else
        {
            return new HammerHarvester(id, oreOutput, energyRequrement);
        }
    }
}