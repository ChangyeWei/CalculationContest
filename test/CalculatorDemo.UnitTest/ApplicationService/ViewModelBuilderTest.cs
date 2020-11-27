using System;
using System.Collections.Generic;
using System.Text;
using CalculatorDemo.Application.ApplicationService;
using FluentAssertions;
using Xunit;

namespace CalculatorDemo.UnitTest.ApplicationService
{
    public class ViewModelBuilderTest
    {
        [Fact]
        public void TestPresent()
        {
            var data = new Stack<decimal>();
            data.Push(1);
            data.Push(2);
            data.Push(3);

            ViewModelBuilder.PresentStack(data).Should().BeEquivalentTo("stack: 1 2 3");

            data.Clear();
            ViewModelBuilder.PresentStack(data).Should().BeEquivalentTo("stack:");

        }

        [Fact]
        public void Test_bigger_Than_10decimal_Present()
        {
            var decimalData = 1.123456789012345m;
            var data = new Stack<decimal>();
            data.Push(decimalData);
            data.Push(2);
            data.Push(3);

            ViewModelBuilder.PresentStack(data).Should().BeEquivalentTo("stack: 1.1234567890 2 3");
            data.Pop().Should().Equals(decimalData);

            data.Clear();
            ViewModelBuilder.PresentStack(data).Should().BeEquivalentTo("stack:");

        }

        [Fact]
        public void Test_less_Than_10decimal_Present()
        {
            var decimalData = 1.1234567m;
            var data = new Stack<decimal>();
            data.Push(decimalData);
            data.Push(2);
            data.Push(3);

            ViewModelBuilder.PresentStack(data).Should().BeEquivalentTo("stack: 1.1234567 2 3");
            data.Pop().Should().Equals(decimalData);

            data.Clear();
            ViewModelBuilder.PresentStack(data).Should().BeEquivalentTo("stack:");

        }
    }
}
