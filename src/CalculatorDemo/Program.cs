using CalculatorDemo.Application.ApplicationService;
using CalculatorDemo.Application.Domain;
using CalculatorDemo.Application.Models;
using System;
using System.Threading.Tasks;
using CalculatorDemo.Application.ApplicationService.Interface;

namespace CalculatorDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start your calculation journey!");

            var calculationContext = new CalculationContext();
            ICalculationService service = new CalculationService(new InputFormatService(new InputService()), new OutputService());
            await service.Calc(calculationContext);

            Console.Read();
        }
    }
}
