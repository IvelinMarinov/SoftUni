using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Hands_of_Cards
{
    public class Program
    {
        public static void Main()
        {
            var scores = new Dictionary<string, int>();
            var playersAndCards = new Dictionary<string, string>();

            while (true)
            {
                var input = Console.ReadLine().Split(':');
                var playerName = input[0];

                if (playerName == "JOKER")
                {
                    break;
                }

                if (playersAndCards.ContainsKey(playerName))
                {
                    playersAndCards[playerName] += input[1];
                }
                else
                {
                    playersAndCards.Add(playerName, input[1]);
                }
            }

            foreach (KeyValuePair<string, string> pCards in playersAndCards)
            {
                var playerCards = new List<string>();

                playerCards = pCards.Value
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Distinct()
                    .ToList();

                var sumOfHand = 0;
                foreach (var card in playerCards)
                {
                    sumOfHand += CardPoints(card);
                }

                if (scores.ContainsKey(pCards.Key))
                {
                    scores[pCards.Key] += sumOfHand;
                }
                else
                {
                    scores.Add(pCards.Key, sumOfHand);
                }
            }

            foreach (KeyValuePair<string, int> score in scores)
            {
                Console.WriteLine($"{score.Key}: {score.Value}");
            }
        }

        private static int CardPoints(string card)
        {
            var power = card[0].ToString();
            var type = card[card.Length - 1].ToString();
            if (power == "1")
            {
                power = "10";
            }
            var powerAsNumber = 0;
            var typeAsNumber = 0;
            var nPower = int.TryParse(power, out powerAsNumber);

            if (nPower == false)
            {
                switch (power)
                {
                    case "J":
                        powerAsNumber = 11;
                        break;
                    case "Q":
                        powerAsNumber = 12;
                        break;
                    case "K":
                        powerAsNumber = 13;
                        break;
                    case "A":
                        powerAsNumber = 14;
                        break;
                }
            }

            switch (type)
            {
                case "S":
                    typeAsNumber = 4;
                    break;
                case "H":
                    typeAsNumber = 3;
                    break;
                case "D":
                    typeAsNumber = 2;
                    break;
                case "C":
                    typeAsNumber = 1;
                    break;
            }

            var cardPoints = powerAsNumber * typeAsNumber;
            return cardPoints;
        }
    }}