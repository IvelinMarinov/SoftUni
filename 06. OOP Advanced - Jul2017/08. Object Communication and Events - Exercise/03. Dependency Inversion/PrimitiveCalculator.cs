
using System.Collections.Generic;
using _03.Dependency_Inversion.Strategies;

namespace _03.Dependency_Inversion
{
    public class PrimitiveCalculator
    {
        private IStrategy strategy;
        //private Dictionary<char, IStrategy> strategies = new Dictionary<char, IStrategy>()
        //{
        //    { '+', new AdditionStrategy()},
        //    { '-', new SubtractionStrategy()},
        //    { '*', new MultiplicationStrategy()},
        //    { '/', new DivisionStrategy()}
        //};

        public PrimitiveCalculator()
        {
            this.strategy = new AdditionStrategy();
            //this.strategy = this.strategies['+'];
        }

        public void changeStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    this.strategy = new AdditionStrategy();
                    break;
                case '-':
                    this.strategy = new SubtractionStrategy();
                    break;
                case '*':
                    this.strategy = new MultiplicationStrategy();
                    break;
                case '/':
                    this.strategy = new DivisionStrategy();
                    break;
            }
            //this.strategy = this.strategies[@operator];
        }

        public int performCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
