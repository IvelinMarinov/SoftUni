using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Parking_System
{
    public class ParkingSystem
    {
        public static void Main()
        {
            var sizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = sizes[0];
            var cols = sizes[1];

            var parking = new Dictionary<int, HashSet<int>>();

            var input = Console.ReadLine();

            while (input != "stop")
            {
                var parameters = input
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var entryRow = parameters[0];
                var desiredRow = parameters[1];
                var desiredCol = parameters[2];

                var parkColumn = 0;

                if (!IsOccupied(parking, desiredRow, desiredCol))
                {
                    parkColumn = desiredCol;
                }
                else
                {
                    for (int i = 1; i < cols - 1; i++)
                    {
                        if (desiredCol - i > 0 && !IsOccupied(parking, desiredRow, desiredCol - i))
                        {
                            parkColumn = (desiredCol - i);
                            break;
                        }

                        if (desiredCol + i < cols && !IsOccupied(parking, desiredRow, desiredCol + i))
                        {
                            parkColumn = (desiredCol + i);
                            break;
                        }
                    }
                }

                if (parkColumn == 0)
                {
                    Console.WriteLine($"Row {desiredRow} full");
                }
                else
                {
                    parking[desiredRow].Add(parkColumn);
                    int steps = Math.Abs(entryRow - desiredRow) + 1 + parkColumn;
                    Console.WriteLine(steps);
                }

                input = Console.ReadLine();
            }
        }

        private static bool IsOccupied(Dictionary<int, HashSet<int>> parking, int row, int col)
        {
            if (parking.ContainsKey(row))
            {
                if (parking[row].Contains(col))
                {
                    return true;
                }
            }
            else
            {
                parking.Add(row, new HashSet<int>());
            }

            return false;
        }
    }
}