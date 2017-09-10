using System;
using System.Collections.Generic;
using System.Linq;

namespace _22._08._2016___01.Second_Nature
{
    public class SecondNature
    {
        public static void Main()
        {
            var flowers = new Queue<long>(Console.ReadLine().Split().Select(long.Parse));
            var buckets = new Stack<long>(Console.ReadLine().Split().Select(long.Parse));
            var ethernalFlowers = new List<long>();
            
            while (flowers.Count != 0 && buckets.Count != 0)
            {
                var currFlower = flowers.Dequeue();
                var currBucket = buckets.Peek();

                if (currFlower == currBucket)
                {
                    buckets.Pop();
                    ethernalFlowers.Add(currFlower);
                }
                else if (currFlower > currBucket)
                {
                    while (currFlower > 0)
                    {
                        currBucket = buckets.Pop();
                        currFlower -= currBucket;

                        if (currFlower == 0)
                        {
                            ethernalFlowers.Add(currFlower);
                        }

                        else if (currFlower < 0)
                        {
                            var waterLeft = Math.Abs(currFlower);
                            if (buckets.Count != 0)
                            {
                                waterLeft += buckets.Pop();
                            }
                            buckets.Push(waterLeft);
                        }

                        else if (currFlower > 0 && buckets.Count == 0)
                        {
                            flowers.Enqueue(currFlower);
                            break;
                        }
                    }
                }
                else if (currFlower < currBucket && buckets.Count != 0)
                {
                    currBucket = buckets.Pop();
                    var waterLeft = currBucket - currFlower;
                    if (buckets.Count != 0)
                    {
                        waterLeft += buckets.Pop();
                    }
                    buckets.Push(waterLeft);
                }
            }

            if (flowers.Count != 0)
            {
                Console.WriteLine(string.Join(" ", flowers));
            }

            else if (buckets.Count != 0)
            {
                Console.WriteLine(string.Join(" ", buckets));

            }

            if (ethernalFlowers.Count != 0)
            {
                Console.WriteLine(string.Join(" ", ethernalFlowers));
            }
            else
            {
                Console.WriteLine("None");
            }

        }
    }
}
