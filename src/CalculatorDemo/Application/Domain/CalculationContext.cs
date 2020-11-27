using System;
using CalculatorDemo.Application.Models;
using CalculatorDemo.Application.SeedWork;
using System.Collections.Generic;

namespace CalculatorDemo.Application.Domain
{
    public class CalculationContext
    {
        public Stack<decimal> CalculationData { get; private set; }

        public Stack<HistoricalData> HistoricalData { get; private set; }

        // todo: check if 'redo' func is need.
        public Stack<HistoricalData> ForwardData { get; private set; }

        public CalculationContext()
        {
            CalculationData = new Stack<decimal>();
            HistoricalData = new Stack<HistoricalData>();
            ForwardData = new Stack<HistoricalData>();
        }

        public void Execute(IEnumerable<InputDto> data)
        {
            if (data.IsNullOrEmpty()) return;

            foreach (var item in data)
            {
                if (TryGetApplicationOperation(item.Input, out var operation))
                {
                    ExecApplicationOperation(operation);
                    continue;
                }

                if (decimal.TryParse(item.Input, out var decimalValue))
                {
                    PushInput(decimalValue);
                }
                else
                {
                    Operation(item);
                }
            }
        }

        private void PushInput(decimal input)
        {
            CalculationData.Push(input);

            HistoricalData.Push(new HistoricalData(new Stack<decimal>(), ApplicationOperationType.Input.Name, 1));
        }

        private void Operation(InputDto inputDto)
        {
            var operationType =
                Enumeration.FromDisplayName<CalculationOperationType>(inputDto.Input, isThrowException: true);

            try
            {
                var (result, history, resultMemberCount) = operationType.Calculator.Calculate(CalculationData);
                CalculationData = result;
                HistoricalData.Push(new HistoricalData(history, operationType.Name, resultMemberCount));
            }
            catch (ParameterCountNotMatchExceptions e)
            {
                throw new ParameterCountNotMatchExceptions(string.Format(e.Message, inputDto.Index));
            }
        }

        private void ExecApplicationOperation(ApplicationOperationType operation)
        {
            var (newNumbers, historyData) = operation.ApplicationOperation.Operate(CalculationData, HistoricalData);

            if (historyData != null)
            {
                HistoricalData.Push(historyData);
            }

            CalculationData = newNumbers;
        }

        private bool TryGetApplicationOperation(string input, out ApplicationOperationType operation)
        {
            operation = Enumeration.FromDisplayName<ApplicationOperationType>(input);
            if (operation == null) return false;

            return true;
        }
    }
}
