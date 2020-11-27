using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CalculatorDemo.Application.ApplicationService;
using CalculatorDemo.Application.ApplicationService.Interface;
using CalculatorDemo.Application.Domain;
using CalculatorDemo.Application.Models;
using FluentAssertions;
using Moq;
using Xunit;

namespace CalculatorDemo.UnitTest.ApplicationService
{
    public class CalculationServiceTest
    {

        [Fact]
        public async Task Calc_Success()
        {
            var inputService = new Mock<IInputFormatService>();
            var outputService = new Mock<IOutputService>();
            var context = new CalculationContext();

            inputService.Setup(s => s.GetInput()).ReturnsInOrderAsync(new List<InputDto>()
            {
                new InputDto("5", 1),
                new InputDto("2", 3),
                new InputDto("-", 5),
            }, null);

            var service = new CalculationService(inputService.Object, outputService.Object);
            await service.Calc(context);

            context.CalculationData.Count.Should().Be(1);
            context.CalculationData.Pop().Should().Be(3);

        }


        [Fact]
        public async Task Calc_ParameterCountNotMatchExceptions()
        {
            var inputService = new Mock<IInputFormatService>();
            var outputService = new Mock<IOutputService>();
            var context = new CalculationContext();

            inputService.Setup(s => s.GetInput()).ReturnsInOrderAsync(new List<InputDto>()
            {
                new InputDto("5", 1),
                new InputDto("2", 3),
                new InputDto("-", 5),
            }, new List<InputDto>()
            {
                new InputDto("-", 1),
            }, null);

            var service = new CalculationService(inputService.Object, outputService.Object);
            await service.Calc(context);
            context.CalculationData.Count.Should().Be(1);
            context.CalculationData.Pop().Should().Be(3);

            outputService.Verify(s => s.Output("operator - (position: 1): insucient parameters"), Times.Once);

        }

        [Fact]
        public async Task Calc_InvalidOperationException()
        {
            var inputService = new Mock<IInputFormatService>();
            var outputService = new Mock<IOutputService>();
            var context = new CalculationContext();

            inputService.Setup(s => s.GetInput()).ReturnsInOrderAsync(new List<InputDto>()
            {
                new InputDto("5", 1),
                new InputDto("2", 3),
                new InputDto("-", 5),
                new InputDto("abc", 7),
            }, null);

            var service = new CalculationService(inputService.Object, outputService.Object);
            await service.Calc(context);
            context.CalculationData.Count.Should().Be(1);
            context.CalculationData.Pop().Should().Be(3);

            outputService.Verify(s => s.Output("'abc' is not a valid display name in CalculatorDemo.Application.Domain.CalculationOperationType"), Times.Once);

        }
    }
}
