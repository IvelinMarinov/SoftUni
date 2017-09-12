using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : ICustomList<T>, IEnumerable<T>
    where T : IComparable<T>
{
    private IList<T> data;

    public CustomList() : this(Enumerable.Empty<T>())
    {
        this.data = new List<T>();
    }

    public CustomList(IEnumerable<T> collection)
    {
        this.data = new List<T>(collection);
    }

    public IList<T> Data => data;
    
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
    
    public IEnumerator<T> GetEnumerator()
    {
        return this.data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}