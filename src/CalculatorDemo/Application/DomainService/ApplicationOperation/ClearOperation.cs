using CalculatorDemo.Application.Domain;
using System.Collections.Generic;

namespace CalculatorDemo.Application.DomainService.ApplicationOperation
{
    public class ClearOperation : IApplicationOperation
    {
        private readonly string _operationName;

        public ClearOperation(string operationName)
        {
            _operationName = operationName;
        }

        public (Stack<decimal> originalNumbers, HistoricalData historyData) Operate(Stack<decimal> numbers, Stack<HistoricalData> historicalDataStack)
        {
            var history = new Stack<decimal>();

            while (numbers.TryPop(out var number))
            {
                history.Push(number);
            }

            // todo: check 'clear' is enable to be 'undo' operation.
            var historyData = new HistoricalData(history, _operationName, 0);

            return (numbers, historyData);
        }
    }
}
