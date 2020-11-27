using System.Collections.Generic;

namespace CalculatorDemo.Application.Domain
{
    public class HistoricalData
    {
        public Stack<decimal> Numbers { get; private set; }
        public string CalculationOperation { get; private set; }
        public int ResultMemberCount { get; private set; }

        public HistoricalData(Stack<decimal> numbers, string calculationOperation, int resultMemberCount)
        {
            Numbers = numbers;
            CalculationOperation = calculationOperation;
            ResultMemberCount = resultMemberCount;
        }
    }
}
