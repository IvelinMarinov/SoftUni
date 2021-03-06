﻿using System;
using System.Text.RegularExpressions;

namespace _05.Extract_Email
{
    public class ExtractEmail
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var pattern = @"\b(?<!\S)[a-z][a-z0-9\.\-_]+[a-z0-9]*@[a-z][a-z\-]+\.[a-z][a-z\.]+[a-z]?\b";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
