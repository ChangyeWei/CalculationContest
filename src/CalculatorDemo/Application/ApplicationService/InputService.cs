using CalculatorDemo.Application.ApplicationService.Interface;
using System;

namespace CalculatorDemo.Application.ApplicationService
{
    public class InputService : IInputService
    {
        public string ReadInput()
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;
            return input.ToLowerInvariant();
        }
    }
}
