using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            long personalIDNumber = long.Parse(Console.ReadLine());
            int uniqueEmployeeNumber = int.Parse(Console.ReadLine());

            Console.Write("First name: ");
            Console.WriteLine(firstName);
            Console.Write("Last name: ");
            Console.WriteLine(lastName);
            Console.Write("Age: ");
            Console.WriteLine(age);
            Console.Write("Gender: ");
            Console.WriteLine(gender);
            Console.Write("Personal ID: ");
            Console.WriteLine(personalIDNumber);
            Console.Write("Unique Employee number: ");
            Console.WriteLine(uniqueEmployeeNumber);

        }
    }
}
