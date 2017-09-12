using System;

public class Engine
{
    public void Start()
    {
        var input = Console.ReadLine().Split();
        var interpreter = new CommandInterpreter();

        while (input[0].ToLower() != "end")
        {
            switch (input[0])
            {
                case "Private":
                    interpreter.AddPrivate(input);
                    break;
                case "LeutenantGeneral":
                    interpreter.AddLeutenantGeneral(input);
                    break;
                case "Engineer":
                    interpreter.AddEngineer(input);
                    break;
                case "Commando":
                    interpreter.AddCommando(input);
                    break;
                case "Spy":
                    interpreter.AddSpy(input);
                    break;
                default:
                    break;
            }

            input = Console.ReadLine().Split();
        }

        interpreter.Print();
    }
}