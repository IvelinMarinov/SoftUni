using System.Collections.Generic;

public class ProviderFactory
{
    public Provider Create(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        if (type.ToLower() == "solar")
        {
            return new SolarProvider(id, energyOutput);
        }
        else
        {
            return new PressureProvider(id, energyOutput);
        }
    }
}