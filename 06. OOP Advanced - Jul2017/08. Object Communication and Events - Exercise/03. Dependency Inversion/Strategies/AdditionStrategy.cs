
using _03.Dependency_Inversion.Strategies;

namespace _03.Dependency_Inversion
{
    public class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
