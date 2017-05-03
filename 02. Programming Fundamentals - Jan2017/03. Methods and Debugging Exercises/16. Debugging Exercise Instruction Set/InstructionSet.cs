using System;
using System.Numerics;

class InstructionSet_broken
{
    static void Main()
    {
        string input = Console.ReadLine();

        while (input != "END")
        {
            BigInteger result = 0;
            var inputArr = input.Split(' ');
            long operandOne = long.Parse(inputArr[1]);

            switch (inputArr[0])
            {
                case "INC":
                    {
                        result = operandOne + 1;
                        break;
                    }
                case "DEC":
                    {
                        result = operandOne - 1;
                        break;
                    }
                case "ADD":
                    {
                        long operandTwo = long.Parse(inputArr[2]);
                        result = operandOne + operandTwo;
                        break;
                    }
                case "MLA":
                    {
                        long operandTwo = long.Parse(inputArr[2]);
                        result = (BigInteger)operandOne * operandTwo;
                        break;
                    }
            }
            Console.WriteLine(result);
            input = Console.ReadLine();
        }        
    }
}