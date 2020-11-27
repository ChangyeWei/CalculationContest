using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorDemo.Application.Models
{
    public class ParameterCountNotMatchExceptions : Exception
    {
        public ParameterCountNotMatchExceptions(string errMsg):base(errMsg)
        {

        }
    }

}
