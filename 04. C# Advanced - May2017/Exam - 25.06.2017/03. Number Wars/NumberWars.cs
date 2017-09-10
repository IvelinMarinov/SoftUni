using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Number_Wars
{
    public class NumberWars
    {
        public static void Main()
        {
            var fistPlayerInput = Console.ReadLine()
                .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var firstPlayerCards = new Queue<string>();

            foreach (var input in fistPlayerInput)
            {
                firstPlayerCards.Enqueue(input);
            }

            var secondPlayerInput = Console.ReadLine()
                .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var secondPlayerCards = new Queue<string>();

            foreach (var input in secondPlayerInput)
            {
                secondPlayerCards.Enqueue(input);
            }

            var turns = 0;
            string outcome = String.Empty;

            while (firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0 && turns < 1000000)
            {
                var fpCurrCard = firstPlayerCards.Dequeue();
                var fpCurrCardNum = long.Parse(fpCurrCard.Substring(0, fpCurrCard.Length - 1));
                
                var spCurrCard = secondPlayerCards.Dequeue();
                var spCurrCardNum = long.Parse(spCurrCard.Substring(0, spCurrCard.Length - 1));

                var winnings = new List<string>();
                winnings.Add(fpCurrCard);
                winnings.Add(spCurrCard);

                if (fpCurrCardNum == spCurrCardNum)
                {
                    outcome = War(firstPlayerCards, secondPlayerCards, winnings);

                    if (outcome == "First player wins")
                    {
                        foreach (var card in winnings
                            .OrderByDescending(x => x.Substring(0, x.Length - 2))
                            .ThenByDescending(x => x[x.Length - 1]))
                        {
                            firstPlayerCards.Enqueue(card);
                        }
                    }
                    else if (outcome == "Second player wins")
                    {
                        foreach (var card in winnings
                            .OrderByDescending(x => x.Substring(0, x.Length - 2))
                            .ThenByDescending(x => x[x.Length - 1]))
                        {
                            secondPlayerCards.Enqueue(card);
                        }
                    }
                }
                else if (fpCurrCardNum < spCurrCardNum)
                {
                    foreach (var card in winnings
                        .OrderByDescending(x => x.Substring(0, x.Length - 2))
                        .ThenByDescending(x => x[x.Length - 1]))
                    {
                        secondPlayerCards.Enqueue(card);
                    }
                }
                else if (fpCurrCardNum > spCurrCardNum)
                {
                    foreach (var card in winnings
                        .OrderByDescending(x => x.Substring(0, x.Length - 2))
                        .ThenByDescending(x => x[x.Length - 1]))
                    {
                        firstPlayerCards.Enqueue(card);
                    }
                }

                turns++;
            }
            if (turns >= 1000000)
            {
                if (firstPlayerCards.Count > secondPlayerCards.Count)
                {
                    outcome = "First player wins";
                }
                else
                {
                    outcome = "Second player wins";
                }
            }

            if (outcome == String.Empty && firstPlayerCards.Count == 0)
            {
                outcome = "Second player wins";
            }
            else if (outcome == String.Empty && secondPlayerCards.Count == 0)
            {
                outcome = "First player wins";
            }

            Console.WriteLine($"{outcome} after {turns} turns");

        }

        private static string War(Queue<string> firstPlayerCards, Queue<string> secondPlayerCards, List<string> winnings)
        {
            var winningPlayer = string.Empty;
            long fpNumbersSum = 0;
            long spNumbersSum = 0;

            if (firstPlayerCards.Count > 0)
            {
                var fpFirstCard = firstPlayerCards.Dequeue();
                fpNumbersSum += fpFirstCard.ToLower()[fpFirstCard.Length - 1] - 96;
                winnings.Add(fpFirstCard);
            }
            else
            {
                return "Second player wins";
            }

            if (firstPlayerCards.Count > 0)
            {
                var fpSecondCard = firstPlayerCards.Dequeue();
                fpNumbersSum += fpSecondCard.ToLower()[fpSecondCard.Length - 1] - 96;
                winnings.Add(fpSecondCard);
            }
            else
            {
                return "Second player wins";
            }

            if (firstPlayerCards.Count > 0)
            {
                var fpThirdCard = firstPlayerCards.Dequeue();
                fpNumbersSum += fpThirdCard.ToLower()[fpThirdCard.Length - 1] - 96;
                winnings.Add(fpThirdCard);
            }
            else
            {
                return "Second player wins";
            }

            if (secondPlayerCards.Count > 0)
            {
                var spFirstCard = secondPlayerCards.Dequeue();
                spNumbersSum += spFirstCard.ToLower()[spFirstCard.Length - 1] - 96;
                winnings.Add(spFirstCard);
            }
            else
            {
                return "First player wins";
            }

            if (secondPlayerCards.Count > 0)
            {
                var spSecondCard = secondPlayerCards.Dequeue();
                spNumbersSum += spSecondCard.ToLower()[spSecondCard.Length - 1] - 96;
                winnings.Add(spSecondCard);
            }
            else
            {
                return "First player wins";
            }

            if (secondPlayerCards.Count > 0)
            {
                var spThirdCard = secondPlayerCards.Dequeue();
                spNumbersSum += spThirdCard.ToLower()[spThirdCard.Length - 1] - 96;
                winnings.Add(spThirdCard);
            }
            else
            {
                return "First player wins";
            }

            if (fpNumbersSum > spNumbersSum)
            {
                winningPlayer = "First player wins";
            }
            else if (fpNumbersSum < spNumbersSum)
            {
                winningPlayer = "Second player wins";
            }
            else if (fpNumbersSum == spNumbersSum && firstPlayerCards.Count == 0 && secondPlayerCards.Count == 0)
            {
                winningPlayer = "Draw";
            }
            else
            {
                winningPlayer = War(firstPlayerCards, secondPlayerCards, winnings);
            }

            return winningPlayer;
        }
    }
}
