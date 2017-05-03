using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concatenate_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter your first name: ");
            var firstName = Console.ReadLine();
            //Console.Write("Enter your last name: ");
            var lastName = Console.ReadLine();
            //Console.Write("Enter your age: ");
            var age = int.Parse(Console.ReadLine());
            //Console.Write("Enter your home town: ");
            var town = Console.ReadLine();

            Console.WriteLine("You are {0} {1}, a {2}-years old person from {3}.", firstName, lastName, age, town);
                       
        }
    }
}
