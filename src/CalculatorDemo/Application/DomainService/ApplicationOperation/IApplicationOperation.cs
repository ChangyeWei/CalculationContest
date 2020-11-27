using CalculatorDemo.Application.Domain;
using System.Collections.Generic;

namespace CalculatorDemo.Application.DomainService.ApplicationOperation
{
    public interface IApplicationOperation
    {
        (Stack<decimal> originalNumbers, HistoricalData historyData) Operate(Stack<decimal> numbers, Stack<HistoricalData> historicalDataStack);
    }
}
