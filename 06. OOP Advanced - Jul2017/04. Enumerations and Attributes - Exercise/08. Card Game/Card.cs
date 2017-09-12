using System;

public class Card : IComparable<Card>
{
    public Card(string rank, string suit)
    {
        this.Rank = (CardRanks)Enum.Parse(typeof(CardRanks), rank);
        this.Suit = (CardSuits)Enum.Parse(typeof(CardSuits), suit);
        this.Power = (int)this.Rank + (int)this.Suit;
    }

    public CardRanks Rank { get; private set; }

    public CardSuits Suit { get; private set; }

    public int Power { get; private set; }


    public int CompareTo(Card other)
    {
        return this.Power - other.Power;
    }

    public override string ToString()
    {
        return $"{this.Rank} of {this.Suit}";
    }
}