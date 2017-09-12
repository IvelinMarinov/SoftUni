using System;

namespace _05.Card_CompareTo
{
    public class StartUp
    {
        public static void Main()
        {
            var cardOneRank = Console.ReadLine();
            var cardOneSuit = Console.ReadLine();
            var cardOne = new Card(cardOneRank, cardOneSuit);

            var cardTwoRank = Console.ReadLine();
            var cardTwoSuit = Console.ReadLine();
            var cardTwo = new Card(cardTwoRank, cardTwoSuit);

            var comparisonResult = cardOne.CompareTo(cardTwo);

            if (comparisonResult > 0)
            {
                Console.WriteLine(cardOne);
            }
            else
            {
                Console.WriteLine(cardTwo);
            }
        }
    }
}
