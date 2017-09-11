using System;

public class Player
{
    private string name;
    private double endurance;
    private double sprint;
    private double dribble;
    private double passing;
    private double shooting;
    private double overallSkillRating;
    
    public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
        this.OverallSkillRating = CalculateOveralRating();
    }

    public double Shooting
    {
        get { return this.shooting; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Shooting should be between 0 and 100.");
            }
            this.shooting = value;
        }
    }

    public double Passing
    {
        get { return this.passing; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Passing should be between 0 and 100.");
            }
            this.passing = value;
        }
    }

    public double Dribble
    {
        get { return this.dribble; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Dribble should be between 0 and 100.");
            }
            this.dribble = value;
        }
    }

    public double Sprint
    {
        get { return this.sprint; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Sprint should be between 0 and 100.");
            }
            this.sprint = value;
        }
    }

    public double Endurance
    {
        get { return this.endurance; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Endurance should be between 0 and 100.");
            }
            this.endurance = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public double OverallSkillRating
    {
        get { return this.overallSkillRating; }
        set
        {
            this.overallSkillRating = value;
        }
    }

    private double CalculateOveralRating()
    {
        return (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5;
    }
}