using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _04.Merge_FIles
{
    public class MergeFiles
    {
        public static void Main()
        {
            var firstInput = File.ReadAllLines("FileOne.txt");
            var secondInput = File.ReadAllLines("FileTwo.txt");

            var mergedInput = new List<string>();

            for (int i = 0; i < firstInput.Length; i++)
            {
                mergedInput.Add(firstInput[i]);
                mergedInput.Add(secondInput[i]);
            }

            File.WriteAllLines("output.txt", mergedInput);
        }
    }
}
