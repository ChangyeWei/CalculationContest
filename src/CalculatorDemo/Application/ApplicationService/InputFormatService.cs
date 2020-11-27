using CalculatorDemo.Application.ApplicationService.Interface;
using CalculatorDemo.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorDemo.Application.ApplicationService
{
    public class InputFormatService : IInputFormatService
    {
        private readonly IInputService _inputService;
        private const string ExitFlag = "exit";

        public InputFormatService(IInputService inputService)
        {
            _inputService = inputService;
        }

        public async Task<List<InputDto>> GetInput()
        {
            var input = _inputService.ReadInput();
            if (input.Equals(ExitFlag, StringComparison.InvariantCultureIgnoreCase)) return null;

            return FormatInput(input);
        }

        private List<InputDto> FormatInput(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<InputDto> result = new List<InputDto>();
            var inputArray = input.ToCharArray();
            char space = (char)32;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] != space)
                {
                    stringBuilder.Append(inputArray[i]);
                    continue;
                }

                SaveOperationToResult(result, stringBuilder, i);
            }

            SaveOperationToResult(result, stringBuilder, inputArray.Length - stringBuilder.ToString().Length + 1);

            return result;
        }

        private void SaveOperationToResult(List<InputDto> result, StringBuilder stringBuilder, int index)
        {
            if (stringBuilder.Capacity == 0)
                return;

            var item = stringBuilder.ToString();
            stringBuilder.Clear();
            if (string.IsNullOrWhiteSpace(item))
                return;

            result.Add(new InputDto(item, index));
        }
    }
}
