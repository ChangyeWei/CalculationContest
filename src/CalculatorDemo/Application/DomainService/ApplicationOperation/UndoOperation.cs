using CalculatorDemo.Application.Domain;
using System.Collections.Generic;

namespace CalculatorDemo.Application.DomainService.ApplicationOperation
{
    public class UndoOperation : IApplicationOperation
    {
        private readonly string _operationName;

        public UndoOperation(string operationName)
        {
            _operationName = operationName;
        }

        public (Stack<decimal> originalNumbers, HistoricalData historyData) Operate(Stack<decimal> numbers, Stack<HistoricalData> historicalDataStack)
        {
            if(!historicalDataStack.TryPop(out var historicalData))
            {
                return (numbers, null);
            }

            for (int i = 0; i < historicalData.ResultMemberCount; i++)
            {
                numbers.Pop();
            }

            while (historicalData.Numbers.TryPop(out var historyData))
            {
                numbers.Push(historyData);
            }

            return (numbers, null);
        }
    }
}
