using System;

namespace _02.Card_Rank
{
    public class StartUp
    {
        public static void Main()
        {
            var cardRanks = Enum.GetValues(typeof(CardRanks));

            Console.WriteLine("Card Ranks:");
            foreach (var cardRank in cardRanks)
            {
                Console.WriteLine($"Ordinal value: {(int)cardRank}; Name value: {cardRank}");
            }
        }
    }
}
