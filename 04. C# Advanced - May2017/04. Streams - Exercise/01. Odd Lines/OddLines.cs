using System;
using System.IO;

namespace _01.Odd_Lines
{
    public class OddLines
    {
        public static void Main()
        {
            using (StreamReader reader = new StreamReader("../../text.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine(); //Skips odd lines
                    line = reader.ReadLine();
                }
            }
        }
    }
}
