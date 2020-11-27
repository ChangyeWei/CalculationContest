using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CalculatorDemo.Application.ApplicationService;
using CalculatorDemo.Application.ApplicationService.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace CalculatorDemo.UnitTest.ApplicationService
{
    public class InputFormatServiceTest
    {
        private readonly Mock<IInputService> _inputService;
        public InputFormatServiceTest()
        {
            _inputService = new Mock<IInputService>();
        }

        [Fact]
        public async Task Input_Split_And_Index()
        {
            _inputService.Setup(s => s.ReadInput()).Returns("1 2 3 4 5 6 7 8 9 + clear");
            var service = new InputFormatService(_inputService.Object);
            var inputList = await service.GetInput();

            inputList.Count.Should().Be(11);
            inputList[0].Input.Should().Be("1");
            inputList[0].Index.Should().Be(1);

            inputList[3].Input.Should().Be("4");
            inputList[3].Index.Should().Be(7);

            inputList[10].Input.Should().Be("clear");
            inputList[10].Index.Should().Be(21);
        }
    }
}
