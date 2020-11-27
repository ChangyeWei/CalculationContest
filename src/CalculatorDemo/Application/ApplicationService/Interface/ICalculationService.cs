using System.Threading.Tasks;
using CalculatorDemo.Application.Domain;

namespace CalculatorDemo.Application.ApplicationService.Interface
{
    public interface ICalculationService
    {
        Task Calc(CalculationContext context);
    }
}
