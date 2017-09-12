using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T> : ICustomList<T>
    where T : IComparable<T>
{
    private IList<T> data;

    public CustomList()
    {
        this.data = new List<T>();
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove(int index)
    {
        T temp = this.data[index];
        this.data.RemoveAt(index);
        return temp;
    }

    public bool Contains(T element)
    {
        return this.data.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        T temp = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        var count = 0;
        foreach (var entry in this.data)
        {
            if (entry.ToString().CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        return this.data.Max();
    }

    public T Min()
    {
        return this.data.Min();
    }

    public string Print()
    {
        var sb = new StringBuilder();
        foreach (var entry in this.data)
        {
            sb.AppendLine(entry.ToString());
        }
        return sb.ToString().Trim();
    }
}