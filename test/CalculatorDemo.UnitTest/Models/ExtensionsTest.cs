using System;
using System.Collections.Generic;
using System.Text;
using CalculatorDemo.Application.SeedWork;
using FluentAssertions;
using Xunit;

namespace CalculatorDemo.UnitTest.Models
{
    public class ExtensionsTest
    {
        [Fact]
        public void Check_List_Null_Empty()
        {
            List<int> emptyList = new List<int>();
            emptyList.IsNullOrEmpty().Should().BeTrue();

            List<int> nullList = null;
            nullList.IsNullOrEmpty().Should().BeTrue();
        }


        [Fact]
        public void Check_Dict_Null_Empty()
        {
            Dictionary<int,int> emptyDict = new Dictionary<int, int>();
            emptyDict.IsNullOrEmpty().Should().BeTrue();

            Dictionary<int, int> nullDict = null;
            nullDict.IsNullOrEmpty().Should().BeTrue();
        }
    }
}
