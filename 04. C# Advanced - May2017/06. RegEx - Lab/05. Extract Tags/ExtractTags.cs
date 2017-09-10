using System;
using System.Text.RegularExpressions;

namespace _05.Extract_Tags
{
    public class ExtractTags
    {
        public static void Main()
        {
            var pattern = "<.+?>";
            var input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            while (input != "END")
            {
                MatchCollection matches = regex.Matches(input);
                
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}
