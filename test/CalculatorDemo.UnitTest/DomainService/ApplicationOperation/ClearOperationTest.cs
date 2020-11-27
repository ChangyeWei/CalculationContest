using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalculatorDemo.Application.DomainService.ApplicationOperation;
using CalculatorDemo.Application.DomainService.CalculationOperation;
using CalculatorDemo.Application.Models;
using FluentAssertions;
using Xunit;

namespace CalculatorDemo.UnitTest.DomainService.ApplicationOperation
{
    public class ClearOperationTest
    {
        private const string Name = "clear";
        private readonly ClearOperation _operator;
        public ClearOperationTest()
        {
            _operator = new ClearOperation(Name);
        }

        [Fact]
        public void Operation_Success()
        {
            var inputStack = new Stack<decimal>();
            inputStack.Push(1);
            inputStack.Push(2);

            var (numbers, historyData) = _operator.Operate(inputStack, null);

            numbers.Count.Should().Be(0);
            historyData.Numbers.Count.Should().Be(2);
            historyData.Numbers.First().Should().Be(1);
            historyData.Numbers.Last().Should().Be(2);
            historyData.ResultMemberCount.Should().Be(0);

        }

    }
}
