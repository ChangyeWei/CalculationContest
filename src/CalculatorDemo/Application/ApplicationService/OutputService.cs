using CalculatorDemo.Application.ApplicationService.Interface;
using System;
using System.Threading.Tasks;

namespace CalculatorDemo.Application.ApplicationService
{
    public class OutputService : IOutputService
    {
        public async Task Output(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
