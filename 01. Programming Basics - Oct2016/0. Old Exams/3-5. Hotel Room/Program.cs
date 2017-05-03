using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_5.Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            var month = Console.ReadLine();
            var days = int.Parse(Console.ReadLine());

            var studioMayOct = 50.0;
            var aptMayOct = 65.0;
            var studioJunSept = 75.20;
            var aptJunSept = 68.70;
            var studioJulAug = 76.0;
            var aptJulAug = 77.0;

            if (month == "May" || month == "October")
            {
                if (days > 7 && days < 14)
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", days * aptMayOct);
                    Console.WriteLine("Studio: {0:f2} lv.", days * studioMayOct * 0.95);
                }
                else if (days > 14)
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", days * aptMayOct * 0.9);
                    Console.WriteLine("Studio: {0:f2} lv.", days * studioMayOct * 0.7);
                }
                else
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", days * aptMayOct);
                    Console.WriteLine("Studio: {0:f2} lv.", days * studioMayOct);
                }
            }
            else if (month == "June" || month == "September")
            {
                
                if (days > 14)
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", days * aptJunSept * 0.9);
                    Console.WriteLine("Studio: {0:f2} lv.", days * studioJunSept * 0.8);
                }
                else
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", days * aptJunSept);
                    Console.WriteLine("Studio: {0:f2} lv.", days * studioJunSept);
                }
            }
            else if (month == "July" || month == "August")
            {              
                if (days > 14)
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", days * aptJulAug * 0.9);
                    Console.WriteLine("Studio: {0:f2} lv.", days * studioJulAug);
                }
                else
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", days * aptJulAug);
                    Console.WriteLine("Studio: {0:f2} lv.", days * studioJulAug);
                }
            }
        }
    }
}
