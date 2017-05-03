using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_1.On_time_for_an_exam
{
    class Program
    {
        static void Main(string[] args)
        {
            var hExam = int.Parse(Console.ReadLine());
            var mExam = int.Parse(Console.ReadLine());
            var hArrival = int.Parse(Console.ReadLine());
            var mArrival = int.Parse(Console.ReadLine());

            var exam = hExam * 60 + mExam;
            var arrival = hArrival * 60 + mArrival;
            var difference = Math.Abs(exam - arrival);

            if (arrival <= exam && arrival >= exam - 30)
            {
                Console.WriteLine("On time");
                if (difference < 60 && difference != 0)
                {
                    Console.WriteLine("{0} minutes before the start", difference);
                }
                else if (difference >= 60 && difference !=0)
                {
                    Console.WriteLine("{0}:{1:00} hours before the start", difference / 60, difference % 60);
                }
            }
            else if (arrival < exam - 30)
            {
                Console.WriteLine("Early");
                if (difference < 60)
                {
                    Console.WriteLine("{0} minutes before the start", difference);
                }
                else
                {
                    Console.WriteLine("{0}:{1:00} hours before the start", difference / 60, difference % 60);
                }
            }
            else
            {
                Console.WriteLine("Late");
                if (difference < 60)
                {
                    Console.WriteLine("{0} minutes after the start", difference);
                }
                else
                {
                    Console.WriteLine("{0}:{1:00} hours after the start", difference / 60, difference % 60);
                }
            }
        }
    }
}