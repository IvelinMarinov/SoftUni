using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _09.Query_Mess
{
    public class QueryMess
    {
        public static void Main()
        {
            var pattern = @"([^&=?]*)=([^&=]*)";
            var regex = @"((%20|\+)+)";

            var input = Console.ReadLine();

            while (input != "END")
            {
                Regex pairs = new Regex(pattern);
                var matches = pairs.Matches(input);
                //var results = new Dictionary<string, List<string>>();
                var results = new Dictionary<string, HashSet<string>>();

                for (int i = 0; i < matches.Count; i++)
                {
                    var field = matches[i].Groups[1].Value;
                    field = Regex.Replace(field, regex, word => " ").Trim();

                    var value = matches[i].Groups[2].Value;
                    value = Regex.Replace(value, regex, word => " ").Trim();

                    if (!results.ContainsKey(field))
                    {
                        //var values = new List<string>();
                        var values = new HashSet<string>();
                        values.Add(value);
                        results.Add(field, values);
                    }
                    else if (results.ContainsKey(field))
                    {
                        results[field].Add(value);
                    }
                }
                foreach (var pair in results)
                {
                    Console.Write("{0}=[{1}]", pair.Key, string.Join(", ", pair.Value));
                }
                Console.WriteLine();

                input = Console.ReadLine();
            }
        }
    }
}
