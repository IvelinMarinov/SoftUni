using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Card_Game
{
    public class StartUp
    {
        public static void Main()
        {
            var playerOneName = Console.ReadLine();
            var playerOne = new Player(playerOneName);
            var playerTwoName = Console.ReadLine();
            var playerTwo = new Player(playerTwoName);
            var allRanks = Enum.GetNames(typeof(CardRanks));
            var allSuits = Enum.GetNames(typeof(CardSuits));
            var deck = allSuits
                .SelectMany(x => allRanks, (x, y) => new Card(y, x))
                .ToList();

            var cardInfo = Console.ReadLine().Split();

            while (playerOne.Hand.Count < 5)
            {
                var rank = cardInfo[0];
                var suit = cardInfo[2];

                try
                {
                    ValidateInput(rank, suit, allRanks, allSuits, deck);
                    var card = new Card(rank, suit);
                    playerOne.Hand.Add(card);
                    deck.RemoveAll(x => x.Power == card.Power);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (playerOne.Hand.Count == 5)
                {
                    break;
                }

                cardInfo = Console.ReadLine().Split();
            }

            cardInfo = Console.ReadLine().Split();

            while (playerTwo.Hand.Count < 5)
            {
                var rank = cardInfo[0];
                var suit = cardInfo[2];

                try
                {
                    ValidateInput(rank, suit, allRanks, allSuits, deck);
                    var card = new Card(rank, suit);
                    playerTwo.Hand.Add(card);
                    deck.RemoveAll(x => x.Power == card.Power);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (playerTwo.Hand.Count == 5)
                {
                    break;
                }

                cardInfo = Console.ReadLine().Split();
            }

            var debug = 0;

            var playerOneMaxCard = playerOne.Hand.Max(x => x.Power);
            var playerTwoMaxCard = playerTwo.Hand.Max(x => x.Power);

            if (playerOneMaxCard > playerTwoMaxCard)
            {
                var winningCard = playerOne.Hand.FirstOrDefault(x => x.Power == playerOneMaxCard);
                Console.WriteLine($"{playerOne.Name} wins with {winningCard}.");
            }
            else
            {
                var winningCard = playerTwo.Hand.FirstOrDefault(x => x.Power == playerTwoMaxCard);
                Console.WriteLine($"{playerTwo.Name} wins with {winningCard}.");
            }
        }
        
        private static void ValidateInput(string rank, string suit, string[] allRanks, string[] allSuits, List<Card> deck)
        {
            if (!allRanks.Contains(rank) || !allSuits.Contains(suit))
            {
                throw new ArgumentException("No such card exists.");
            }
            
            var card = new Card(rank, suit);

            if (!deck.Any(x => x.Power == card.Power))
            {
                throw new ArgumentException("Card is not in the deck.");
            }
        }
    }
}
