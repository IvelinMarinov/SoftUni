using System;
using System.IO;
using System.Linq;

namespace _05.Folder_size
{
    public class FolderSize
    {
        public static void Main()
        {
            var totalSize = Directory
                .GetFiles("TestFolder")
                .Select(f => new FileInfo(f))
                .Sum(f => f.Length / 1024.0 / 1024.0);

            Console.WriteLine(totalSize);
        }
    }
}
