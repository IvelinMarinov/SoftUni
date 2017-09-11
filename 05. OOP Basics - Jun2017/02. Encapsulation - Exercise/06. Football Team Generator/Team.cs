using System;
using System.Collections.Generic;
using System.Linq;

class Team
{
    private string name;
    private List<Player> players;
    private double rating;

    public Team(string name)
    {
        this.Name = name;
        this.Players = new List<Player>();
    }

    public double Rating
    {
        get { return this.rating; }
        set { this.rating = value; }
    }

    public List<Player> Players
    {
        get { return this.players; }
        set { this.players = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public double CalculateRating()
    {
        if (Players.Count == 0)
        {
            return 0;
        }

        return Math.Round(Players.Sum(p => p.OverallSkillRating) / Players.Count);
    }
}