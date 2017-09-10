using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _0.Set_vs.List_Performance
{
    public class SetVsListPerformance
    {
        public static void Main()
        {
            var list = new List<string>();

            var watch1 = Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i.ToString());
            }

            watch1.Stop();
            Console.WriteLine($"List add (in ms): {watch1.ElapsedMilliseconds}");
            Console.WriteLine($"List add (in ticks): {watch1.ElapsedTicks}");

            var watch2 = Stopwatch.StartNew();

            var someBool = list.Contains("999999");

            watch2.Stop();

            Console.WriteLine($"List contains (in ms): {watch2.ElapsedMilliseconds}");
            Console.WriteLine($"List contains (in ticks): {watch2.ElapsedTicks}");

            var watch3 = Stopwatch.StartNew();
            list.Max();
            watch3.Stop();

            Console.WriteLine($"List Max (in ms): {watch3.ElapsedMilliseconds}");
            Console.WriteLine($"List Max (in ticks): {watch3.ElapsedTicks}");
            Console.WriteLine();

            /////////////////////////////////////////////////////////////////

            var set = new HashSet<string>();

            var watch4 = Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                set.Add(i.ToString());
            }

            watch4.Stop();
            Console.WriteLine($"Set add (in ms): {watch4.ElapsedMilliseconds}");
            Console.WriteLine($"Set add (in ticks): {watch4.ElapsedTicks}");

            var watch5 = Stopwatch.StartNew();

            someBool = list.Contains("999999");

            watch5.Stop();

            Console.WriteLine($"Set contains (in ms): {watch5.ElapsedMilliseconds}");
            Console.WriteLine($"Set contains (in ticks): {watch5.ElapsedTicks}");

            var watch6 = Stopwatch.StartNew();
            set.Max();
            watch6.Stop();

            Console.WriteLine($"Set Max (in ms): {watch6.ElapsedMilliseconds}");
            Console.WriteLine($"Set Max (in ticks): {watch6.ElapsedTicks}");
        }
    }
}
