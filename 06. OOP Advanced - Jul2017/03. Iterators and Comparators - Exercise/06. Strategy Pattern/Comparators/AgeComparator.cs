using System.Collections.Generic;

namespace _06.Strategy_Pattern
{
    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age - y.Age;
        }
    }
}