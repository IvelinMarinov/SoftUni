using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000_days_from_birth
{
    class Program
    {
        static void Main(string[] args)
        {
            string DateString = Console.ReadLine();
            string format = "dd-MM-yyyy";
            DateTime result = DateTime.ParseExact(DateString, format, CultureInfo.InvariantCulture);
            DateTime answer = result.AddDays(999);

            Console.WriteLine(answer.ToString(format));
        }
    }
}
