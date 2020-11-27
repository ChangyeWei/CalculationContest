using System;
using System.Collections.Generic;
using System.Text;
using CalculatorDemo.Application.Domain;
using CalculatorDemo.Application.SeedWork;
using FluentAssertions;
using Xunit;

namespace CalculatorDemo.UnitTest.Domain
{
    public class EnumerationTypeTest
    {
        [Fact]
        public void Application_Operation_Type_Test()
        {
            var applicationOperationType = Enumeration.FromDisplayName<ApplicationOperationType>(ApplicationOperationType.Input.Name);
            applicationOperationType.Should().Equals(ApplicationOperationType.Input);

            Assert.Throws<InvalidOperationException>(() => Enumeration.FromDisplayName<ApplicationOperationType>("whatEver", true));

            var nullType = Enumeration.FromDisplayName<ApplicationOperationType>("whatEver");
            nullType.Should().BeNull();
        }
    }
}
