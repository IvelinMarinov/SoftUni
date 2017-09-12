using System;

namespace _03.Dependency_Inversion.Strategies
{
    public class MultiplicationStrategy : IStrategy
    {
        public int Calculate(int first, int second)
        {
            return first * second;
        }
    }
}
