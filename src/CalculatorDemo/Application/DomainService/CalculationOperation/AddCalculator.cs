﻿using CalculatorDemo.Application.Models;
using CalculatorDemo.Application.SeedWork;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorDemo.Application.DomainService.CalculationOperation
{
    public class AddCalculator : ICalculator
    {
        private readonly string _name;

        public AddCalculator(string name)
        {
            _name = name;
        }

        public (Stack<decimal> afterCalc, Stack<decimal> history, int resultMemberCount) Calculate(Stack<decimal> numbers)
        {
            int memberParticipant = 2;
            int resultMemberCount = 1;
            if (numbers.IsNullOrEmpty() || numbers.Count < memberParticipant)
            {
                throw new ParameterCountNotMatchExceptions("operator "+ _name + " (position: {0}): insucient parameters");
            }

            var history = new Stack<decimal>();
            for (int i = 0; i < memberParticipant; i++)
            {
                history.Push(numbers.Pop());
            }
            numbers.Push(history.Sum());

            return (numbers, history, resultMemberCount);
        }
    }
}
