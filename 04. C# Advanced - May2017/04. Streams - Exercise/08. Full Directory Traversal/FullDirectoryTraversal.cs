using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace _08.Full_Directory_Traversal
{
    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Please enter the directory you want to traverse:");
            var directory = Console.ReadLine();
            var report = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directorySelected = new DirectoryInfo(directory);
            FileInfo[] files = directorySelected.GetFiles();
            DirectoryInfo[] subDirectories = directorySelected.GetDirectories();

            GetFileInfo(report, files, subDirectories);
            SortAndWrite(report);

            stopwatch.Stop();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"{stopwatch.ElapsedTicks} ticks");
        }

        private static void SortAndWrite(Dictionary<string, Dictionary<string, double>> report)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var sortedReport = report.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            using (StreamWriter destination = new StreamWriter($"{desktopPath}\\report.txt"))
            {
                foreach (var entry in sortedReport)
                {
                    destination.WriteLine($"{entry.Key} ({entry.Value.Count} files)");
                    Console.WriteLine($"{entry.Key} ({entry.Value.Count} files)");
                    foreach (var kvp in entry.Value.OrderBy(x => x.Value))
                    {
                        destination.WriteLine($"--{kvp.Key} - {kvp.Value / 1024:F3}kb");
                        Console.WriteLine($"--{kvp.Key} - {kvp.Value / 1024:F3}kb");
                    }
                }
            }
        }

        private static void GetFileInfo(Dictionary<string, Dictionary<string, double>> report, FileInfo[] files, DirectoryInfo[] subDirectories)
        {
            if (subDirectories != null)
            {
                foreach (var subDirectory in subDirectories)
                {
                    DirectoryInfo directorySelected = new DirectoryInfo(subDirectory.FullName);
                    FileInfo[] subDirectoryFiles = directorySelected.GetFiles();
                    DirectoryInfo[] subSubDirectories = directorySelected.GetDirectories();
                    GetFileInfo(report, subDirectoryFiles, subSubDirectories);
                }
            }

            foreach (var file in files)
            {
                if (!report.ContainsKey(file.Extension))
                {
                    report.Add(file.Extension, new Dictionary<string, double>());
                    report[file.Extension].Add(file.Name, file.Length);
                }
                else
                {
                    if (!report[file.Extension].ContainsKey(file.Name))
                    {
                        report[file.Extension].Add(file.Name, file.Length);
                    }
                }
            }
        }
    }
}
