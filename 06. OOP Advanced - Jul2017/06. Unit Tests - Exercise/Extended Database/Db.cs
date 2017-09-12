using System;
using System.Linq;

namespace Extended_Database
{
    public class Db
    {
        public const int ArrayLength = 16;

        public Db(params Person[] initialPersons)
        {
            if (initialPersons.Length > ArrayLength)
            {
                throw new InvalidOperationException();
            }

            this.Collection = new Person[ArrayLength];

            for (int i = 0; i < initialPersons.Length; i++)
            {
                this.Collection[i] = initialPersons[i];
            }

            this.CurrLenght = initialPersons.Length;
        }

        public Person[] Collection { get; }

        public int CurrLenght { get; private set; }

        public void Add(Person person)
        {
            //bool x = this.CurrLenght == ArrayLength;
            //bool y = this.Collection.Where(p => p != null).Any(per => per.Id == person.Id);
            //bool z = this.Collection.Where(p => p != null).Any(per => per.Username == person.Username);

            if (this.CurrLenght == ArrayLength 
                || this.Collection.Where(p => p != null).Any(per => per.Id == person.Id)
                || this.Collection.Where(p => p != null).Any(per => per.Username == person.Username))
            {
                throw new InvalidOperationException();
            }

            this.Collection[this.CurrLenght] = person;
            this.CurrLenght++;
        }

        public void Remove()
        {
            if (this.CurrLenght == 0)
            {
                throw new InvalidOperationException();
            }

            this.Collection[this.CurrLenght] = null;
            this.CurrLenght--;
        }

        public Person FindByUsername(string username)
        {
            if (username == null || username == string.Empty)
            {
                throw new ArgumentNullException();
            }

            if (!this.Collection.Where(p => p != null).Any(p => p.Username == username))
            {
                throw new InvalidOperationException();
            }

            var result = this.Collection.FirstOrDefault(p => p.Username == username);

            return result;
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!this.Collection.Where(p => p != null).Any(p => p.Id == id))
            {
                throw new InvalidOperationException();
            }
            
            var result = this.Collection.FirstOrDefault(p => p.Id == id);

            return result;
        }
    }
}
