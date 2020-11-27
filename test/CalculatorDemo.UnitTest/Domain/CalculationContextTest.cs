using System;
using System.Collections.Generic;
using System.Text;
using CalculatorDemo.Application.ApplicationService;
using CalculatorDemo.Application.ApplicationService.Interface;
using CalculatorDemo.Application.Domain;
using CalculatorDemo.Application.Models;
using FluentAssertions;
using Xunit;

namespace CalculatorDemo.UnitTest.Domain
{
    public class CalculationContextTest
    {
        [Fact]
        public void Test_ApplicationInput()
        {
            var context = new CalculationContext();
            var list = new List<InputDto>();
            list.Add(new InputDto("5",0));
            list.Add(new InputDto("2", 3));

            context.Execute(list);
            context.CalculationData.Count.Should().Be(2);
            context.CalculationData.Pop().Should().Be(2);
            context.CalculationData.Pop().Should().Be(5);

            context.HistoricalData.Count.Should().Be(2);
            context.HistoricalData.Pop().CalculationOperation.Should().Equals(ApplicationOperationType.Input.Name);
            context.HistoricalData.Pop().CalculationOperation.Should().Equals(ApplicationOperationType.Input.Name);
        }

        [Fact]
        public void Test_Cal_Operation()
        {
            var context = new CalculationContext();
            var list = new List<InputDto>();
            list.Add(new InputDto("5", 0));
            list.Add(new InputDto("2", 3));
            list.Add(new InputDto("-", 5));

            context.Execute(list);
            context.CalculationData.Count.Should().Be(1);
            context.CalculationData.Pop().Should().Be(3);

            context.HistoricalData.Count.Should().Be(3);
            context.HistoricalData.Pop().CalculationOperation.Should().Equals(CalculationOperationType.Sub.Name);
            context.HistoricalData.Pop().CalculationOperation.Should().Equals(ApplicationOperationType.Input.Name);
            context.HistoricalData.Pop().CalculationOperation.Should().Equals(ApplicationOperationType.Input.Name);
        }

        [Fact]
        public void Test_Application_Operation()
        {
            var context = new CalculationContext();
            var list = new List<InputDto>();
            list.Add(new InputDto("5", 0));
            list.Add(new InputDto("2", 3));
            list.Add(new InputDto("-", 5));
            list.Add(new InputDto("clear", 7));

            context.Execute(list);
            context.CalculationData.Count.Should().Be(0);

            context.HistoricalData.Count.Should().Be(4);
            context.HistoricalData.Pop().CalculationOperation.Should().Equals(ApplicationOperationType.Clear.Name);
            context.HistoricalData.Pop().CalculationOperation.Should().Equals(CalculationOperationType.Sub.Name);
            context.HistoricalData.Pop().CalculationOperation.Should().Equals(ApplicationOperationType.Input.Name);
            context.HistoricalData.Pop().CalculationOperation.Should().Equals(ApplicationOperationType.Input.Name);
        }

        [Fact]
        public void Test_Invalid_Input()
        {
            var context = new CalculationContext();
            var list = new List<InputDto>();
            list.Add(new InputDto("5", 0));
            list.Add(new InputDto("2", 3));
            list.Add(new InputDto("-", 5));
            list.Add(new InputDto("invalid", 7));

            Assert.Throws<InvalidOperationException>(() => context.Execute(list));
        }
    }
}
