using System.Collections.Generic;

public class Player
{
    public string Name { get; set; }

    public IList<Card> Hand { get; set; }

    public int MaxCardPower { get; set; }

    public Player(string name)
    {
        this.Name = name;
        this.Hand = new List<Card>();
    }
}