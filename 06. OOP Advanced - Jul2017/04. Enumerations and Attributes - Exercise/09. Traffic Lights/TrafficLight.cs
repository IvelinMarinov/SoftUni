using System;

public class TrafficLight
{
    public LightColors Light { get; private set; }

    public TrafficLight(string light)
    {
        this.Light = (LightColors)Enum.Parse(typeof(LightColors), light);
    }

    public void ChangeLight()
    {
        this.Light++;
        if ((int)this.Light > 2)
        {
            this.Light = 0;
        }
    }

    public override string ToString()
    {
        return this.Light.ToString();
    }
}