using System;
using System.Collections.Generic;

namespace _10.Simple_Text_Editor
{
    public class SimpleTextEditor
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var text = string.Empty;
            var updatedText = string.Empty;
            var changeLog = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "1":
                        var textToConcat = command[1];
                        updatedText = string.Concat(text, textToConcat);
                        changeLog.Push(text);
                        text = updatedText;                        
                        break;

                    case "2":
                        var charsToErase = int.Parse(command[1]);
                        updatedText = text.Substring(0, text.Length - charsToErase);
                        changeLog.Push(text);
                        text = updatedText;
                        break;

                    case "3":
                        var index = int.Parse(command[1]);
                        Console.WriteLine(text[index - 1]);
                        break;

                    case "4":
                        text = changeLog.Pop();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
