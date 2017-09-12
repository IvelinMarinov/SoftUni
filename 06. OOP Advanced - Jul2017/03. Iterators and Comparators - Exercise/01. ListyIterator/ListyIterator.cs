using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerator<T>
{
    private int currentIndex;
    private IList<T> collection;
    
    public ListyIterator(IList<T> collection)
    {
        this.Reset();
        this.collection = collection;
    }
    
    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (this.currentIndex + 1 < this.collection.Count)
        {
            this.currentIndex++;
            return true;
        }

        return false;
    }

    public bool Move()
    {
        return this.MoveNext();
    }

    public bool HasNext()
    {
        if (this.currentIndex + 1 < this.collection.Count)
        {
            return true;
        }
        return false;
    }

    public void Print()
    {
        if (this.collection.Count == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }
        Console.WriteLine(this.Current.ToString());
    }

    public void Reset()
    {
        this.currentIndex = 0;
    }

    public T Current
    {
        get { return this.collection[this.currentIndex]; }
    }

    object IEnumerator.Current
    {
        get { return this.Current; }
    }
}