using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Greater_of_Two_Values
{
    class Program
    {
        static int GetMax(int firstValue, int secondValue)
        {
            return Math.Max(firstValue, secondValue);
        }

        static char GetMax(char firstValue, char secondValue)
        {
            return (char) Math.Max((int)firstValue, (int)secondValue);
        }

        static string GetMax(string firstValue, string secondValue)
        {
            if (firstValue.CompareTo(secondValue) > 0)
            {
                return secondValue;
            }
            else
            {
                return firstValue;
            }
        }

        static void Main(string[] args)
        {
            var dataType = Console.ReadLine();

            

            if (dataType == "int")
            {
                int firstValue = int.Parse(Console.ReadLine());
                int secondValue = int.Parse(Console.ReadLine());

                int result = GetMax(firstValue, secondValue);
                Console.WriteLine(result);
            }
            else if (dataType == "char")
            {
                char firstValue = Console.ReadKey().KeyChar;
                char secondValue = Console.ReadKey().KeyChar;

                char result = GetMax(firstValue, secondValue);
                Console.WriteLine(result);
            }
            else if (dataType == "string")
            {
                string firstValue = Console.ReadLine();
                string secondValue = Console.ReadLine();

                string result = GetMax(firstValue, secondValue);
                Console.WriteLine(result);
            }

            
        }
    }
}
