using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private string corps;

    public Engineer(string id, string firstName, string lastName, double salary, string corps, IList<IRepair> repairs)
        : base(id, firstName, lastName, salary, corps)
    {        
        Repairs = repairs;
    }
        
    public IList<IRepair> Repairs { get; }
    
    public override string ToString()
    {
        var sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
        sb.AppendLine("Repairs:");
        sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", this.Repairs)}");
        return sb.ToString().Trim();
    }
}