using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _19.Thea_The_Photographer
{
    class TheaThePhotographer
    {
        static void Main()
        {
            int numOfPictures = int.Parse(Console.ReadLine());
            int filterTimePerPic = int.Parse(Console.ReadLine());
            int filterFactor = int.Parse(Console.ReadLine());
            int uploadTimePerPic = int.Parse(Console.ReadLine());

            BigInteger filterTimeTotal = (BigInteger)numOfPictures * filterTimePerPic;
            int filteredPics = (int)Math.Ceiling((double)numOfPictures / 100 * filterFactor);
            BigInteger uploadTimeTotal = (BigInteger)filteredPics * uploadTimePerPic;
            BigInteger totalTime = filterTimeTotal + uploadTimeTotal;

            TimeSpan A = TimeSpan.FromSeconds((double)totalTime);
            
            Console.WriteLine("{0}:{1:00}:{2:00}:{3:00}", A.Days, A.Hours, A.Minutes, A.Seconds);

            //BigInteger days = totalTime / 86400;
            //totalTime = totalTime % 86400;
            //BigInteger hours = totalTime / 3600;
            //totalTime = totalTime % 3600;
            //BigInteger mins = totalTime / 60;
            //BigInteger secs = totalTime % 60;

            //Console.WriteLine("{0}:{1:00}:{2:00}:{3:00}", days, hours, mins, secs);
        }
    }
}
