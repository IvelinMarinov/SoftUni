using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Hornet_Comm
{
    public class Program
    {
        public static void Main()
        {
            var privateMessagePattern = @"^(\d+)\s<->\s([\d\w]+)$";
            var broadcastPattern = @"^(\D+)\s<->\s([\d\w]+)$";

            Regex privateMessageRegex = new Regex(privateMessagePattern);
            Regex broadcastRegex = new Regex(broadcastPattern);

            var privateMessagesSummary = new List<PrivateMessage>();
            var broadcastsSummmary = new List<Broadcast>();

            var commData = Console.ReadLine();

            while (commData != "Hornet is Green")
            {
                var privateMessageMatch = privateMessageRegex.Match(commData);
                var broadcastMatch = broadcastRegex.Match(commData);

                if (privateMessageRegex.IsMatch(commData))
                {
                    var recipientArr = privateMessageMatch.Groups[1].Value.Reverse().ToArray();
                    var recipient = string.Join("", recipientArr);
                    var message = privateMessageMatch.Groups[2].Value;

                    var currentPrivateMessage = new PrivateMessage()
                    {
                        Recipient = recipient,
                        Message = message
                    };

                    privateMessagesSummary.Add(currentPrivateMessage);
                }

                else if (broadcastRegex.IsMatch(commData))
                {
                    var message = broadcastMatch.Groups[1].Value;
                    var frequency = broadcastMatch.Groups[2].Value;
                    var sb = new StringBuilder();

                    for (int i = 0; i < frequency.Length; i++)
                    {
                        if ((int)frequency[i] >= 65 && (int)frequency[i] <= 90)
                        {
                            sb.Append((char)(frequency[i] + 32));

                        }
                        else if ((int)frequency[i] >= 97 && (int)frequency[i] <= 122)
                        {
                            sb.Append((char)(frequency[i] - 32));
                        }
                        else
                        {
                            sb.Append(frequency[i]);
                        }
                    }

                    var changedBroadcast = sb.ToString();

                    var currentBroadcast = new Broadcast()
                    {
                        Frequency = changedBroadcast,
                        Message = message
                    };

                    broadcastsSummmary.Add(currentBroadcast);
                }

                commData = Console.ReadLine();
            }

            Console.WriteLine($"Broadcasts:");

            if (broadcastsSummmary.Count == 0)
            {
                Console.WriteLine("None");
            }

            foreach (var broadcast in broadcastsSummmary)
            {
                Console.WriteLine($"{broadcast.Frequency} -> {broadcast.Message}");
            }

            Console.WriteLine($"Messages:");

            if (privateMessagesSummary.Count == 0)
            {
                Console.WriteLine("None");
            }

            foreach (var privateMessage in privateMessagesSummary)
            {
                Console.WriteLine($"{privateMessage.Recipient} -> {privateMessage.Message}");
            }
        }
        
    }
}
