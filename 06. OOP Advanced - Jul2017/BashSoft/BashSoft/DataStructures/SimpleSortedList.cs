using BashSoft.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BashSoft.DataStructures
{
    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private T[] innerCollection;
        private int size;
        private IComparer<T> comparison;

        public SimpleSortedList(IComparer<T> comparer, int capacity)
        {
            this.InitializeinnerCollection(capacity);
            this.comparison = comparer;
        }

        public SimpleSortedList(int capacity) 
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList()
            : this(DefaultSize)
        {
        }

        public SimpleSortedList(IComparer<T> comparer) 
            : this(comparer, DefaultSize)
        {
        }

        public bool Remove(T element)
        {
            bool hasBeenRemoved = false;
            int indexOfRemovedElement = 0;
            for (int i = 0; i < this.Size; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfRemovedElement = i;
                    this.innerCollection[i] = default(T);
                    hasBeenRemoved = true;
                    break;
                }
            }

            if (hasBeenRemoved)
            {
                for (int i = indexOfRemovedElement; i < this.Size - 1; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                }

                this.innerCollection[this.size - 1] = default(T);
            }

            return hasBeenRemoved;
        }

        public int Capacity
        {
            get { return this.innerCollection.Length; }
        }

        public int Size
        {
            get { return this.size; }
        }

        private void InitializeinnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.innerCollection = new T[capacity];
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw  new ArgumentNullException();
            }

            if (this.innerCollection.Length == this.size)
            {
                Resize();
            }

            this.innerCollection[size] = element;
            this.size++;
            Array.Sort(this.innerCollection, 0, size, comparison);
        }

        public void AddAll(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Size + collection.Count >= this.innerCollection.Length)
            {
                this.MultiResize(collection);
            }

            foreach (var element in collection)
            {
                this.innerCollection[this.Size] = element;
                this.size++;
            }

            Array.Sort(this.innerCollection, 0, this.size, this.comparison);
        }

        public string JoinWith(string joiner)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var element in this)
            {
                builder.Append(element);
                builder.Append(joiner);
            }

            builder.Remove(builder.Length - 1, 1);

            return builder.ToString();
        }

        private void Resize()
        {
            T[] newCollection = new T[this.Size * 2];
            Array.Copy(innerCollection, newCollection, Size);
            innerCollection = newCollection;
        }

        private void MultiResize(ICollection<T> collection)
        {
            int newSize = this.innerCollection.Length * 2;
            while (this.Size + collection.Count >= newSize)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.size);
            this.innerCollection = newCollection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}