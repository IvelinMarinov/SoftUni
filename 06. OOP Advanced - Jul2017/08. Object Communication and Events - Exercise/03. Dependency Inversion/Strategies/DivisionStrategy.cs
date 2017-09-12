
namespace _03.Dependency_Inversion.Strategies
{
    public class DivisionStrategy : IStrategy
    {
        public int Calculate(int first, int second)
        {
            return first / second;
        }
    }
}
