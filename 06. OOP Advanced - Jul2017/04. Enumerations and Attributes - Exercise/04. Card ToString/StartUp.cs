using System;

namespace _04.Card_ToString
{
    public class StartUp
    {
        public static void Main()
        {
            var cardRank = Console.ReadLine();
            var cardSuit = Console.ReadLine();

            var card = new Card(cardRank, cardSuit);
            Console.WriteLine(card);
        }
    }
}
