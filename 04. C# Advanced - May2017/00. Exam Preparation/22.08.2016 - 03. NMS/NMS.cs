using System;
using System.Collections.Generic;
using System.Text;

namespace _22._08._2016___03.NMS
{
    public class NMS
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            var sb = new StringBuilder();

            while (inputLine != "---NMS SEND---")
            {
                sb.Append(inputLine);
                inputLine = Console.ReadLine();
            }

            var input = sb.ToString() + ' ';

            var words = new List<string>();

            var word = string.Empty;

            for (int i = 0; i < input.Length - 1; i++)
            {
                word += input[i];

                if (char.ToLower(input[i]) <= char.ToLower(input[i + 1]))
                {
                    continue;
                }
                else
                {
                    words.Add(word);
                    word = string.Empty;
                }

            }

            var delimiter = Console.ReadLine();

            Console.WriteLine(string.Join(delimiter, words));
        }
    }
}
