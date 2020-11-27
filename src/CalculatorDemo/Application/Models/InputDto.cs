using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorDemo.Application.Models
{
    public class InputDto
    {
        public string Input { get; private set; }
        public int Index { get; private set; }

        public InputDto(string input, int index)
        {
            Input = input;
            Index = index;
        }
    }
}
