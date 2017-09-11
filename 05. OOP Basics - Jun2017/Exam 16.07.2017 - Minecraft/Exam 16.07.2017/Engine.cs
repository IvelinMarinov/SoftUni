using System;
using System.Linq;

public class Engine
{
    public void Start()
    {
        string command;

        var manager = new DraftManager();
        bool shouldContinue = true;

        var input = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();


        while (shouldContinue)
        {
            switch (input[0])
            {
                case "RegisterHarvester":
                    input.RemoveAt(0);
                    Console.WriteLine(manager.RegisterHarvester(input)); ;
                    break;
                case "RegisterProvider":
                    input.RemoveAt(0);
                    Console.WriteLine(manager.RegisterProvider(input)); ;
                    break;
                case "Day":
                    Console.WriteLine(manager.Day());
                    break;
                case "Mode":
                    input.RemoveAt(0);
                    Console.WriteLine(manager.Mode(input));
                    break;
                case "Check":
                    input.RemoveAt(0);
                    Console.WriteLine(manager.Check(input));
                    break;
                case "Shutdown":
                    Console.WriteLine(manager.ShutDown());
                    shouldContinue = false;
                    break;
            }
            if (!shouldContinue)
            {
                break;
            }

            input = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }


    }
}