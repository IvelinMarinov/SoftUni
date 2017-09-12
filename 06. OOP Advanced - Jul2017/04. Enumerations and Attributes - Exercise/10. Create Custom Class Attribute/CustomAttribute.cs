using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomAttribute : Attribute
{
    public CustomAttribute(string author, int revision, string description, params string[] reviewers)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.Reviewers = reviewers.ToList();
    }

    public string Author { get; private set; }

    public int Revision { get; private set; }

    public string Description { get; private set; }

    public IList<string> Reviewers { get; private set; }

    public string GetAuthor()
    {
        return $"Author: {this.Author}";
    }

    public string GetRevision()
    {
        return $"Revision: {this.Revision}";
    }

    public string GetDescription()
    {
        return $"Class description: Used for C# OOP Advanced Course - Enumerations and Attributes.";
    }

    public string GetReviewers()
    {
        return $"Reviewers: {string.Join(", ", this.Reviewers)}";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"author: {this.Author}")
            .AppendLine($"Revision: {this.Revision}")
            .AppendLine($"Class description: Used for C# OOP Advanced Course - Enumerations and Attributes.")
            .AppendLine($"Reviewers: {string.Join(", ", this.Reviewers)}");

        return sb.ToString();
    }


}