using CalculatorDemo.Application.Models;
using CalculatorDemo.Application.SeedWork;
using System;
using System.Collections.Generic;

namespace CalculatorDemo.Application.DomainService.CalculationOperation
{
    public class SqrtCalculator : ICalculator
    {
        private readonly string _name;

        public SqrtCalculator(string name)
        {
            _name = name;
        }

        public (Stack<decimal> afterCalc, Stack<decimal> history, int resultMemberCount) Calculate(Stack<decimal> numbers)
        {
            int memberParticipant = 1;
            int resultMemberCount = 1;
            if (numbers.IsNullOrEmpty())
            {
                throw new ParameterCountNotMatchExceptions("operator " + _name + " (position: {0}): insucient parameters");
            }

            var value = numbers.Pop();
            numbers.Push((decimal) Math.Sqrt((double)value));

            var history = new Stack<decimal>();
            history.Push(value);

            return (numbers, history, resultMemberCount);
        }
    }
}
