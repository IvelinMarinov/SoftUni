using System;

namespace _01.Card_Suit
{
    public class StartUp
    {
        public static void Main()
        {
            var cardSuits = Enum.GetValues(typeof(CardSuits));

            Console.WriteLine("Card Suits:");
            CardSuits parseResult;

            foreach (var cardSuit in cardSuits)
            {
                Console.WriteLine($"Ordinal value: {(int)cardSuit} Name value: {cardSuit}");
            }
        }
    }
}
