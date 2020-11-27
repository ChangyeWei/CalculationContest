using System.Collections.Generic;

namespace CalculatorDemo.Application.DomainService.CalculationOperation
{
    public interface ICalculator
    {
        (Stack<decimal> afterCalc, Stack<decimal> history, int resultMemberCount) Calculate(Stack<decimal> numbers);
    }
}
