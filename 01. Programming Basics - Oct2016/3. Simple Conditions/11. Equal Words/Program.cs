using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string word1 = Console.ReadLine();
            string word1Lowercase = word1.ToLower();
            string word2 = Console.ReadLine();
            string word2lowercase = word2.ToLower();

            if (word1Lowercase == word2lowercase)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");            }
            
        }
    }
}
