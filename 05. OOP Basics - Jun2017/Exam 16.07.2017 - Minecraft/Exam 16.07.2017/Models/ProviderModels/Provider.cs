using System;

public abstract class Provider : Element
{
    private double energyOutput;

    protected Provider(string id, double eneryOutput)
        : base(id)
    {
        this.Id = id;
        this.EnergyOutput = eneryOutput;
    }
    
    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
            }
            energyOutput = value;
        }
    }    
}