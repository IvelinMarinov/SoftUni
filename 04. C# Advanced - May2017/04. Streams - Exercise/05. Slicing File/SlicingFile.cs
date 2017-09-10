using System;
using System.IO;
using System.Linq;

namespace _05.Slicing_File
{
    public class SlicingFile
    {
        public static void Main()
        {
            using (FileStream source = new FileStream("../../source.jpg", FileMode.Open, FileAccess.Read))
            {
                Console.Write("Please enter the number of parts you want the file sliced into: ");
                var parts = int.Parse(Console.ReadLine());

                var destinationDirectory = "../../";
                var bufferSize = source.Length / parts;

                Slice(source, destinationDirectory, parts);

                Console.WriteLine("Files sliced successfully!");
                Console.WriteLine();
                Console.WriteLine($"Please indicate how you want the parts to be allocated in the new file (ex. \"3 1 2...\")");
                var newAllocation = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                Assemble(newAllocation, destinationDirectory, bufferSize);
                Console.WriteLine("File assembled successfully!");
            }
        }

        private static void Assemble(int[] newAllocation, string destinationDirectory, long bufferSize)
        {
            using (FileStream assembler = new FileStream($"{destinationDirectory}assembled.jpg", FileMode.Create))
            {
                for (int i = 1; i <= newAllocation.Length; i++)
                {
                    using (FileStream partsReader = new FileStream($"../../Part-{newAllocation[i - 1]}.jpg", FileMode.Open))
                    {
                        var buffer = new byte[bufferSize];
                        var readBytes = partsReader.Read(buffer, 0, buffer.Length);
                        assembler.Write(buffer, 0, readBytes);
                    }
                }
            }
        }

        private static void Slice(FileStream source, string destinationDirectory, int parts)
        {
            for (int i = 1; i <= parts; i++)
            {
                using (FileStream destination = new FileStream($"{destinationDirectory}Part-{i}.jpg", FileMode.Create))
                {
                    var buffer = new byte[source.Length / parts];
                    var readBytes = source.Read(buffer, 0, buffer.Length);
                    destination.Write(buffer, 0, readBytes);
                }
            }
        }
    }
}
