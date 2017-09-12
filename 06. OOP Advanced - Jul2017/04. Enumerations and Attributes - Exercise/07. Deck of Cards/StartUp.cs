using System;
using System.Linq;

namespace _07.Deck_of_Cards
{
    public class StartUp
    {
        public static void Main()
        {
            var allRanks = Enum.GetNames(typeof(CardRanks));
            var allSuits = Enum.GetNames(typeof(CardSuits));

            var deck = allSuits
                .SelectMany(x => allRanks, (x, y) => new Card(y,x))
                .ToList();

            foreach (var card in deck)
            {
                Console.WriteLine(card);
            }
        }
    }
}
