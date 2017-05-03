using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation_III___4.Files
{
    public class Files
    {
        public static void Main()
        {
            var fileRecord = new Dictionary<string, Dictionary<string, long>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var filePath = Console.ReadLine()
                    .Split(new[] { '\\', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var currRoot = filePath[0];
                var fileNameAndExt = filePath[filePath.Count - 2];
                var fileSize = long.Parse(filePath[filePath.Count - 1]);

                if (!fileRecord.ContainsKey(currRoot))
                {
                    fileRecord.Add(currRoot, new Dictionary<string, long>());
                }

                if (!fileRecord[currRoot].ContainsKey(fileNameAndExt))
                {
                    fileRecord[currRoot].Add(fileNameAndExt, fileSize);
                }

                else
                {
                    fileRecord[currRoot][fileNameAndExt] = fileSize;
                }
            }

            var queryParams = Console.ReadLine().Split();

            var queryExt = queryParams[0];
            var queryRoot = queryParams[2];

            if (fileRecord.ContainsKey(queryRoot))
            {
                var foundFiles = fileRecord[queryRoot];

                foreach (var file in foundFiles.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    if (file.Key.EndsWith(queryExt))
                    {
                        Console.WriteLine($"{file.Key} - {file.Value} KB");
                    }
                }
            }
            else
            {
                Console.WriteLine("No");
            }            
        }
    }
}
