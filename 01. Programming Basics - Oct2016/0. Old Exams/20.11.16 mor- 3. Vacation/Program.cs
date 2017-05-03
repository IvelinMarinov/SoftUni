using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._11._16_mor__3.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            var numAdults = int.Parse(Console.ReadLine());
            var numStudents = int.Parse(Console.ReadLine());
            var numNights = int.Parse(Console.ReadLine());
            var transportation = Console.ReadLine();

            var adultsTrain = 24.99;
            var adultsBus = 32.50;
            var adultsShip = 42.99;
            var adultsPlane = 70.00;
            var studentsTrain = 14.99;
            var studentsBus = 28.50;
            var studentsShip = 39.99;
            var studentsPlane = 50.00;
            var priceNight = 82.99;
            var comission = 0.1;
            var totalTranport = 0.00;

            if (transportation == "train")
            {
                if (numAdults + numStudents >= 50)
                {
                    totalTranport = (numAdults * adultsTrain * 0.5) + (numStudents * studentsTrain * 0.5);
                }
                else
                {
                    totalTranport = (numAdults * adultsTrain) + (numStudents * studentsTrain);
                }
            }
            else if (transportation == "bus")
            {
                totalTranport = (numAdults * adultsBus) + (numStudents * studentsBus);
            }
            else if (transportation == "boat")
            {
                totalTranport = (numAdults * adultsShip) + (numStudents * studentsShip);
            }
            else if (transportation == "airplane")
            {
                totalTranport = (numAdults * adultsPlane) + (numStudents * studentsPlane);
            }

            var totalCost = ((totalTranport*2) + (numNights * priceNight)) * 1.1;
            Console.WriteLine("{0:f2}", totalCost);




        }
    }
}
