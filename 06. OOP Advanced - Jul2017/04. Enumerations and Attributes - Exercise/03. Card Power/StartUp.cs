using System;

namespace _03.Card_Power
{
    public class StartUp
    {
        public static void Main()
        {
            var cardRank = Console.ReadLine();
            var cardSuit = Console.ReadLine();

            var cardRankValue = (int)Enum.Parse(typeof(CardRanks), cardRank);
            var cardSuitValue = (int)Enum.Parse(typeof(CardSuits), cardSuit);
            var cardPower = cardRankValue + cardSuitValue;

            Console.WriteLine($"Card name: {cardRank} of {cardSuit}; Card power: {cardPower}");
        }
    }
}
