using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    public IList<T> Data { get; set; }

    public Box()
    {
        this.Data = new List<T>();
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        var firstElement = this.Data[firstIndex];
        var secondElement = this.Data[secondIndex];
        this.Data[firstIndex] = secondElement;
        this.Data[secondIndex] = firstElement;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var element in Data)
        {
            sb.AppendLine($"{element.GetType().FullName}: {element}");
        }

        return sb.ToString().Trim();
    }
}