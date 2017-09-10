using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.Directory_Traversal
{
    public class DirectoryTraversal
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the directory you want to traverse:");
            var directory = Console.ReadLine();
            var report = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directorySelected = new DirectoryInfo(directory);
            FileInfo[] files = directorySelected.GetFiles();

            GetFileInfo(report, files);
            SortAndWrite(report);
        }

        private static void SortAndWrite(Dictionary<string, Dictionary<string, double>> report)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var sortedReport = report.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            using (StreamWriter destination = new StreamWriter($"{desktopPath}\\report.txt"))
            {
            foreach (var entry in sortedReport)
                {
                    destination.WriteLine(entry.Key);
                    foreach (var kvp in entry.Value.OrderBy(x => x.Value))
                    {
                        destination.WriteLine($"--{kvp.Key} - {kvp.Value / 1024:F3}kb");
                    }
                }
            }
        }

        private static void GetFileInfo(Dictionary<string, Dictionary<string, double>> report, FileInfo[] files)
        {
            foreach (var file in files)
            {
                if (!report.ContainsKey(file.Extension))
                {
                    report.Add(file.Extension, new Dictionary<string, double>());
                    report[file.Extension].Add(file.Name, file.Length);
                }
                else
                {
                    report[file.Extension].Add(file.Name, file.Length);
                }
            }
        }
    }
}
