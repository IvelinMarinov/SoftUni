using System;
using System.Collections.Generic;

public class CommandInterpreter
{
    Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();
  
    public void AddPrivate(string[] input)
    {
        soldiers.Add(input[1], new Private(input[1], input[2], input[3], double.Parse(input[4])));
    }

    public void AddLeutenantGeneral(string[] input)
    {
        var privatesInCommand = new List<ISoldier>();

        for (int i = 5; i < input.Length; i++)
        {
            privatesInCommand.Add(soldiers[input[i]]);
        }

        soldiers.Add(input[1], new LeutenantGeneral(input[1], input[2], input[3], double.Parse(input[4]), privatesInCommand));
    }

    public void AddEngineer(string[] input)
    {
        if (input[5] != "Airforces" && input[5] != "Marines")
        {
            return;
        }

        var repairs = new List<IRepair>();

        for (int i = 6; i < input.Length; i = i + 2)
        {
            repairs.Add(new Repair(input[i], int.Parse(input[i + 1])));
        }

        soldiers.Add(input[1], new Engineer(input[1], input[2], input[3], double.Parse(input[4]), input[5], repairs));
    }

    public void AddCommando(string[] input)
    {
        if (input[5] != "Airforces" && input[5] != "Marines")
        {
            return;
        }

        IList<IMission> missions = new List<IMission>();

        for (int i = 6; i < input.Length; i = i + 2)
        {
            if (input[i + 1] != "inProgress" && input[i + 1] != "Finished")
            {
                continue;
            }
            missions.Add(new Mission(input[i], input[i + 1]));
        }

        soldiers.Add(input[1], new Commando(input[1], input[2], input[3], double.Parse(input[4]), input[5], missions));
    }

    public void AddSpy(string[] input)
    {
        soldiers.Add(input[1], new Spy(input[1], input[2], input[3], int.Parse(input[4])));
    }

    public void Print()
    {
        foreach (var soldier in soldiers.Values)
        {
            Console.WriteLine(soldier);
        }
    }
}