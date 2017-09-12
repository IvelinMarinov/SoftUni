using System;
using System.Collections;
using System.Collections.Generic;
namespace ListIterator_Problem
{
    public class ListIterator<T> : IEnumerator<T>
    {
        private int currentIndex;
        private IList<T> collection;

        public ListIterator(IList<T> collection)
        {
            this.Reset();
            this.Collection = collection;
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
            private set { this.currentIndex = value; }
        }

        public IList<T> Collection
        {
            get { return this.collection; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.collection = value;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.CurrentIndex + 1 < this.Collection.Count)
            {
                this.CurrentIndex++;
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
            if (this.CurrentIndex + 1 < this.Collection.Count)
            {
                return true;
            }
            return false;
        }

        public string Print()
        {
            if (this.Collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            return this.Current.ToString();
        }

        public void Reset()
        {
            this.CurrentIndex = 0;
        }

        public T Current
        {
            get { return this.Collection[this.CurrentIndex]; }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }
    }
}
