using System;

namespace Database_Problem
{
    public class Db
    {
        public const int ArrayLength = 16;

        public Db(params int[] initialNumbers)
        {
            if (initialNumbers.Length > ArrayLength)
            {
                throw new InvalidOperationException();
            }

            this.Collection = new int[ArrayLength];

            for (int i = 0; i < initialNumbers.Length; i++)
            {
                this.Collection[i] = initialNumbers[i];
            }

            this.CurrLenght = initialNumbers.Length;
        }

        public int[] Collection { get; }

        public int CurrLenght { get; private set; }

        public void Add(int number)
        {
            if (this.CurrLenght == ArrayLength)
            {
                throw new InvalidOperationException();
            }

            this.Collection[this.CurrLenght] = number;
            this.CurrLenght++;
        }

        public void Remove()
        {
            if (this.CurrLenght == 0)
            {
                throw new InvalidOperationException();
            }

            this.Collection[this.CurrLenght] = 0;
            this.CurrLenght--;
        }

        public int[] Fetch()
        {
            var result = new int[this.CurrLenght];

            for (int i = 0; i < this.CurrLenght; i++)
            {
                result[i] = this.Collection[i];
            }

            return result;
        }
    }
}
