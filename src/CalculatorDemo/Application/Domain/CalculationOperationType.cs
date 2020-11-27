using CalculatorDemo.Application.DomainService.CalculationOperation;
using CalculatorDemo.Application.SeedWork;

namespace CalculatorDemo.Application.Domain
{
    public class CalculationOperationType : Enumeration
    {
        public static CalculationOperationType Add = new CalculationOperationType(0, "+", new AddCalculator("+"));
        public static CalculationOperationType Sub = new CalculationOperationType(1, "-", new SubCalculator("-"));
        public static CalculationOperationType Multiple =
            new CalculationOperationType(2, "*", new MultipleCalculator("*"));
        public static CalculationOperationType Divide = new CalculationOperationType(3, "/", new DivideCalculator("/"));
        public static CalculationOperationType Sqrt = new CalculationOperationType(4, nameof(Sqrt).ToLowerInvariant(),
            new SqrtCalculator(nameof(Sqrt).ToLowerInvariant()));

        protected CalculationOperationType(int id, string name, ICalculator calculator) : base(id, name)
        {
            Calculator = calculator;
        }

        public ICalculator Calculator { get; private set; }
    }
}
