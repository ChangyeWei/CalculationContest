using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalculatorDemo.Application.Domain;
using CalculatorDemo.Application.DomainService.ApplicationOperation;
using CalculatorDemo.Application.DomainService.CalculationOperation;
using CalculatorDemo.Application.Models;
using FluentAssertions;
using Xunit;

namespace CalculatorDemo.UnitTest.DomainService.ApplicationOperation
{
    public class UndoOperationTest
    {
        private const string Name = "undo";
        private readonly UndoOperation _operator;
        public UndoOperationTest()
        {
            _operator = new UndoOperation(Name);
        }

        [Fact]
        public void Undo_Sub()
        {
            var inputStack = new Stack<decimal>();
            inputStack.Push(10);
            inputStack.Push(2);

            var historyStack = new Stack<decimal>();
            historyStack.Push(1);
            historyStack.Push(3);

            var historyDataStack = new Stack<HistoricalData>();
            historyDataStack.Push(new HistoricalData(historyStack, CalculationOperationType.Sub.Name, 1));

            var (numbers, historyData) = _operator.Operate(inputStack, historyDataStack);

            numbers.Count.Should().Be(3);
            numbers.Pop().Should().Be(1);
            numbers.Pop().Should().Be(3);
            numbers.Pop().Should().Be(10);
            historyDataStack.Count.Should().Be(0);
            historyData.Should().BeNull();
        }

    }
}
