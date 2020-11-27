using CalculatorDemo.Application.DomainService.CalculationOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalculatorDemo.Application.Models;
using FluentAssertions;
using Xunit;

namespace CalculatorDemo.UnitTest.DomainService.CalculationOperation
{
    public class AddCalculatorTest
    {
        private const string Name = "+";
        private readonly AddCalculator _calculator;
        public AddCalculatorTest()
        {
            _calculator = new AddCalculator(Name);
        }

        [Fact]
        public void Calc_Success()
        {
            var inputStack = new Stack<decimal>();
            inputStack.Push(1);
            inputStack.Push(2);

            var (result, history, resultMemberCount) = _calculator.Calculate(inputStack);
            result.Count.Should().Be(1);
            result.First().Should().Be(3);
            history.Count.Should().Be(2);
            history.First().Should().Be(1);
            history.Last().Should().Be(2);
            resultMemberCount.Should().Be(1);
        }

        [Fact]
        public void Calc_Insucient_Parameters()
        {
            var inputStack = new Stack<decimal>();
            inputStack.Push(1);

            var exception = Assert.Throws<ParameterCountNotMatchExceptions>(() => _calculator.Calculate(inputStack));
            exception.Message.Should().Be("operator " + Name + " (position: {0}): insucient parameters");
        }
    }
}
