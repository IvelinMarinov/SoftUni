using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private IList<T> collection;

    public Stack()
    {
        this.collection = new List<T>();
    }

    public void Push(T element)
    {
        this.collection.Add(element);
    }

    public void Pop()
    {
        if (this.collection.Count == 0)
        {
            throw new ArgumentException("No elements");
        }

        this.collection.RemoveAt(this.collection.Count - 1);

    }

    public IEnumerator<T> GetEnumerator()
    {
        return new StackIterator<T>(this.collection);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }



    class StackIterator<T> : IEnumerator<T>
    {
        private int currentIndex;
        private IList<T> collection;

        public StackIterator(IList<T> collection)
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

        public void Reset()
        {
            this.currentIndex = -1;
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
}