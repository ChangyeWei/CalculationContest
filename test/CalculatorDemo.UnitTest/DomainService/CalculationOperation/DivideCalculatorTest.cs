using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalculatorDemo.Application.DomainService.CalculationOperation;
using CalculatorDemo.Application.Models;
using FluentAssertions;
using Xunit;

namespace CalculatorDemo.UnitTest.DomainService.CalculationOperation
{
    public class DivideCalculatorTest
    {
        private const string Name = "/";
        private readonly DivideCalculator _calculator;
        public DivideCalculatorTest()
        {
            _calculator = new DivideCalculator(Name);
        }

        [Fact]
        public void Calc_Success()
        {
            var inputStack = new Stack<decimal>();
            inputStack.Push(1);
            inputStack.Push(2);

            var (result, history, resultMemberCount) = _calculator.Calculate(inputStack);
            result.Count.Should().Be(1);
            result.First().Should().Be(0.5m);
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
