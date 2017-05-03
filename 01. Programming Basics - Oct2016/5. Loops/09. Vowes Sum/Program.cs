using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowesSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputText = Console.ReadLine();
            var sum = 0;

            for (int i = 0; i < inputText.Length; i++)
            {
                var letter = inputText[i];

                switch (letter)
                {
                    case 'a':
                        sum += 1;
                        break;
                    case 'e':
                        sum += 2;
                        break;
                    case 'i':
                        sum += 3;
                        break;
                    case 'o':
                        sum += 4;
                        break;
                    case 'u':
                        sum += 5;
                        break;                      

                    default:
                        break;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
