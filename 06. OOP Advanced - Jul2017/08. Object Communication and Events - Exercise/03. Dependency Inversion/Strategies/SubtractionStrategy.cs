
using _03.Dependency_Inversion.Strategies;

namespace _03.Dependency_Inversion
{
    class SubtractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
