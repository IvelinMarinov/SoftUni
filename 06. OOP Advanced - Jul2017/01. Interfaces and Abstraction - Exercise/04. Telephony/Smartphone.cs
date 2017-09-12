using System;

public class Smartphone : IPhone, ISmartphone
{
    public Smartphone()
    {
    }

    public string Call(string phoneNumber)
    {
        foreach (var digit in phoneNumber)
        {
            if (!char.IsDigit(digit))
            {
                throw new ArgumentException("Invalid number!");
            }
        }

        return $"Calling... {phoneNumber}";
    }

    public string Browse(string url)
    {
        foreach (var ch in url)
        {
            if (char.IsDigit(ch))
            {
                throw new ArgumentException("Invalid URL!");
            }
        }

        return $"Browsing: {url}!";
    }
}