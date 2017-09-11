using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private double totalEnergyStored;
    private double totalOreStored;
    private string currentMode;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];

        try
        {
            harvesters.Add(id, harvesterFactory.Create(arguments));
            return $"Successfully registered {type} Harvester - {id}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];

        try
        {
            providers.Add(id, providerFactory.Create(arguments));
            return $"Successfully registered {type} Provider - {id}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        var totalEnergyProducedPerDay = this.providers.Values.Select(x => x.EnergyOutput).Sum();
        totalEnergyStored += totalEnergyProducedPerDay;
        double totalEnergyRequredPerDay = 0;
        double totalOreProducedPerDay = 0;
        double totalOreMinedToday = 0;

        switch (this.currentMode)
        {
            case "Full":
            case null:
                totalEnergyRequredPerDay = this.harvesters.Values.Select(x => x.EnergyRequirement).Sum();
                totalOreProducedPerDay = this.harvesters.Values.Select(x => x.OreOutput).Sum();
                break;
            case "Half":
                totalEnergyRequredPerDay = this.harvesters.Values.Select(x => x.EnergyRequirement).Sum() * 60 / 100;
                totalOreProducedPerDay = this.harvesters.Values.Select(x => x.OreOutput).Sum() * 50 / 100;
                break;
            case "Energy":
                totalEnergyRequredPerDay = 0;
                totalOreProducedPerDay = 0;
                break;
        }

        if (totalEnergyStored >= totalEnergyRequredPerDay)
        {
            totalOreMinedToday = totalOreProducedPerDay;
            totalEnergyStored -= totalEnergyRequredPerDay;
            totalOreStored += totalOreProducedPerDay;
        }
        
        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {totalEnergyProducedPerDay}");
        sb.AppendLine($"Plumbus Ore Mined: {totalOreMinedToday}");

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var mode = arguments[0];

        switch (mode)
        {
            case "Full":
                this.currentMode = "Full";
                break;
            case "Half":
                this.currentMode = "Half";
                break;
            case "Energy":
                this.currentMode = "Energy";
                break;
        }

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        if (providers.ContainsKey(id))
        {
            return providers[id].Print();
        }
        else if (harvesters.ContainsKey(id))
        {
            return harvesters[id].Print();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalEnergyStored}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalOreStored}");

        return sb.ToString().Trim();
    }
}