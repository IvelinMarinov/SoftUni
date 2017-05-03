using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Hands_of_Cards
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(':').ToList();

            var playerCards = new Dictionary<string, string>();

            while (input[0] != "JOKER")
            {
                if (!playerCards.ContainsKey(input[0]))
                {
                    playerCards[input[0]] = input[1];
                }
                else
                {
                    playerCards[input[0]] += input[1];
                }

                input = Console.ReadLine().Split(':').ToList();
            }

            foreach (var item in playerCards)
            {                
                var sum = 0;

                var cards = item.Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();

                foreach (var card in cards)
                {
                    var power = 0;
                    
                    switch (card.Substring(0, card.Length - 1))
                    {
                        case "2": power = 2; break;
                        case "3": power = 3; break;
                        case "4": power = 4; break;
                        case "5": power = 5; break;
                        case "6": power = 6; break;
                        case "7": power = 7; break;
                        case "8": power = 8; break;
                        case "9": power = 9; break;
                        case "10": power = 10; break;
                        case "J": power = 11; break;
                        case "Q": power = 12; break;
                        case "K": power = 13; break;
                        case "A": power = 14; break;
                        default: break;
                    }
                    var multiplicator = 0;

                    switch (card.Substring(card.Length - 1))
                    {
                        case "S": multiplicator = 4; break;
                        case "H": multiplicator = 3; break;
                        case "D": multiplicator = 2; break;
                        case "C": multiplicator = 1; break;
                        default: break;
                    }

                    var cardValue = power * multiplicator;
                    sum += cardValue;
                }
                Console.WriteLine($"{item.Key}: {sum}");

            }
        }
    }
}
