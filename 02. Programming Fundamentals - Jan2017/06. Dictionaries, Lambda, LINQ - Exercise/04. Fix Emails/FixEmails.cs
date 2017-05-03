using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fix_Emails
{
    public class FixEmails
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var inputList = new List<string>();

            while (input != "stop")
            {
                inputList.Add(input);
                input = Console.ReadLine();
            }

            var emailDict = new Dictionary<string, string>();

            for (int i = 0; i < inputList.Count - 1; i = i + 2)
            {
                if (!inputList[i + 1].EndsWith("uk") && !inputList[i + 1].EndsWith("us"))
                {
                    emailDict[inputList[i]] = inputList[i + 1];
                }                
            }
                 
            foreach (var email in emailDict)
            {
                Console.WriteLine($"{email.Key} -> {email.Value}");
            }
        }
    }
}
