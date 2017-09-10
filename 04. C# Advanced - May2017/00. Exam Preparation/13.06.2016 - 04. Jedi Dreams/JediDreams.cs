using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _19._06._2016___04.Jedi_Dreams
{
    public class JediDreams
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            var brackets = new Stack<char>();
            bool anchor = false;
            var methodStrings = new List<string>();
            var methods = new List<string>();
            var results = new List<Method>();
            string line;

            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();

                if (line.Contains('{'))
                {
                    brackets.Push('{');
                    anchor = true;
                }
                sb.Append(line).Append(" ");
                if (line.Contains('}'))
                {
                    brackets.Pop();
                }
                if (brackets.Count == 0 && sb.ToString().Trim() != string.Empty && anchor)
                {
                    methodStrings.Add(sb.ToString());
                    sb.Clear();
                }
            }

            if (sb.Length != 0)
            {
                methodStrings.Add(sb.ToString());
            }

            methodStrings = methodStrings.Select(x => x.Trim()).ToList();

            for (int i = 0; i < methodStrings.Count - 1; i++)
            {
                if (methodStrings[i].StartsWith("s") && methodStrings[i].EndsWith("}"))
                {
                    methods.Add(methodStrings[i]);
                    continue;
                }

                if (methodStrings[i][0] == 's' && methodStrings[i + 1][0] == '{')
                {
                    methods.Add(string.Concat(methodStrings[i], " ", methodStrings[i + 1]));
                }
            }

            string pattern = @"static\s.*?\s([A-Z]{1}[a-zA-Z]{0,})\(.*?\).*?([A-Z]{1}[a-zA-Z]{0,})\(.*?\)";
            Regex regex = new Regex(pattern);

            for (var i = 0; i < methods.Count; i++)
            {
                var method = methods[i];

                if (regex.IsMatch(method))
                {
                    var methodObj = new Method();
                    methodObj.Name = regex.Match(method).Groups[1].Value;
                    methodObj.Invokes = new List<string>();

                    while (regex.Match(method).Groups[2].Value != string.Empty)
                    {
                        var invoke = regex.Match(method).Groups[2].Value;
                        methodObj.Invokes.Add(invoke);
                        var firstIndex = method.IndexOf(invoke);
                        method = method.Substring(0, firstIndex) + method.Substring(firstIndex + invoke.Length);
                    }

                    results.Add(methodObj);
                }
            }

            foreach (var methodObj in results
                .OrderByDescending(x => x.Invokes.Count)
                .ThenBy(x => x.Name))
            {
                if (methodObj.Invokes.Count != 0)
                {
                    Console.WriteLine($"{methodObj.Name} -> {methodObj.Invokes.Count} -> {string.Join(", ", methodObj.Invokes.OrderBy(x => x))}");
                }
            }
        }
    }
}
