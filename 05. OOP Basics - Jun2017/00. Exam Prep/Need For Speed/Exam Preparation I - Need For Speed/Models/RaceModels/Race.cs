﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private Dictionary<int,Car> participants;
    private List<Car> winners;
    
    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
        this.Winners = new List<Car>();
    }

    public List<Car> Winners
    {
        get { return this.winners; }
        set { this.winners = value; }
    }

    public Dictionary<int, Car> Participants
    {
        get { return this.participants; }
        set { this.participants = value; }
    }

    public int PrizePool
    {
        get { return this.prizePool; }
        set { this.prizePool = value; }
    }

    public string Route
    {
        get { return this.route; }
        set { this.route = value; }
    }

    public int Length
    {
        get { return this.length; }
        set { this.length = value; }
    }

    public abstract int GetPerformance(int id);

    public List<int> GetPrizes()
    {
        var result = new List<int>();
        result.Add((this.prizePool * 50) / 100);
        result.Add((this.prizePool * 30) / 100);
        result.Add((this.prizePool * 20) / 100);
        return result;
    }

    public string Start()
    {
        var winners = GetWinners();
        var sb = new StringBuilder();

        if (this.Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        sb.AppendLine($"{route} - {length}");

        var counter = 1;
        for (int i = 0; i < winners.Count; i++)
        {
            var car = winners.ElementAt(i);
            sb.AppendLine(
                $"{i + 1}. {car.Value.Brand} {car.Value.Model} {this.GetPerformance(car.Key)}PP - ${GetPrizes()[i]}");
        }

        return sb.ToString().Trim();
    }

    public Dictionary<int,Car> GetWinners()
    {
        var winners = this.Participants
            .OrderByDescending(n => this.GetPerformance(n.Key)).Take(3)
            .ToDictionary(n => n.Key, m => m.Value);

        return winners;
    }
}