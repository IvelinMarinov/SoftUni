using System;

namespace _07.Custom_List
{
    public class StartUp
    {
        public static void Main()
        {
            ICustomList<string> myCustomList = new CustomList<string>(); 

            var input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                switch (input[0])
                {
                    case "Add":
                        myCustomList.Add(input[1]);
                        break;
                    case "Remove":
                        myCustomList.Remove(int.Parse(input[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(myCustomList.Contains(input[1]));
                        break;
                    case "Swap":
                        myCustomList.Swap(int.Parse(input[1]), int.Parse(input[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(myCustomList.CountGreaterThan(input[1]));
                        break;
                    case "Max":
                        Console.WriteLine(myCustomList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(myCustomList.Min());
                        break;
                    case "Print":
                        Console.WriteLine(myCustomList.Print());
                        break;
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
