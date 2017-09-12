using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(string id, string firstName, string lastName, double salary, IList<ISoldier> privatesInCommand)
        : base(id, firstName, lastName, salary)
    {
        this.PrivatesInCommand = privatesInCommand;
    }
    
    public IList<ISoldier> PrivatesInCommand { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
        sb.AppendLine("Privates:");
        sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", this.PrivatesInCommand)}");
        return sb.ToString().Trim();
    }
}