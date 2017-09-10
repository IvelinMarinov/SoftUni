using System;
using System.Linq;

namespace _02.Parse_URLs
{
    public class ParseURLs
    {
        public static void Main()
        {
            var url = Console.ReadLine();

            var urlArr = url
                .Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (urlArr.Length != 2 || urlArr[1].IndexOf('/') < 0)
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            var protocol = urlArr[0];
            var serverAndResource = urlArr[1];
            var firstIndexOfSlash = serverAndResource.IndexOf('/');
            var server = serverAndResource.Substring(0, firstIndexOfSlash);
            var resources = serverAndResource.Substring(firstIndexOfSlash + 1);

            Console.WriteLine($"Protocol = {protocol}");
            Console.WriteLine($"Server = {server}");
            Console.WriteLine($"Resources = {resources}");
        }
    }
}
