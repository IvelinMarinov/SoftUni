using BashSoft.Contracts;
using System;

namespace BashSoft
{
    public class InputReader : IInputReader
    {
        private const string endCommand = "quit";
        private IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionsData.currentPath}> ");
                string input = Console.ReadLine();
                input = input.Trim();
                if (input == endCommand)
                {
                    break;
                }
                interpreter.InterpredCommand(input);
            }
        }
    }
}