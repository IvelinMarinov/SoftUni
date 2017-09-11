using System;

public class DateModifier
{
    public DateModifier(string firstDate, string secondDate)
    {
        this.firstDate = firstDate;
        this.secondDate = secondDate;
    }

    public string firstDate;
    public string secondDate;

    public DateTime FirstDate
    {
        get
        {
            return DateTime.Parse(this.firstDate);
        }
    }

    public DateTime SecondDate
    {
        get
        {
            return DateTime.Parse(this.secondDate);
        }
    }

    public int difference
    {
        get
        {
            return Math.Abs((FirstDate - SecondDate).Days);
        }
    }
}