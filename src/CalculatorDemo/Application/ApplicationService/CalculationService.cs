using CalculatorDemo.Application.ApplicationService.Interface;
using System;
using System.Threading.Tasks;
using CalculatorDemo.Application.Domain;
using CalculatorDemo.Application.Models;

namespace CalculatorDemo.Application.ApplicationService
{
    public class CalculationService : ICalculationService
    {
        private readonly IInputFormatService _inputService;
        private readonly IOutputService _outputService;
        private static bool IsDebugEnable = true;

        public CalculationService(IInputFormatService inputService, IOutputService outputService)
        {
            _inputService = inputService;
            _outputService = outputService;
        }

        public async Task Calc(CalculationContext context)
        {
            var input = await _inputService.GetInput();
            while (input != null)
            {
                try
                {
                    context.Execute(input);
                }
                catch (ParameterCountNotMatchExceptions e)
                {
                    await _outputService.Output(e.Message);
                }
                catch (InvalidOperationException invalidOperation)
                {
                    await _outputService.Output(invalidOperation.Message);
                }
                catch (Exception unExpectedException)
                {
                    if (IsDebugEnable)
                    {
                        await _outputService.Output(unExpectedException.ToString());
                    }
                    else
                    {
                        await _outputService.Output("system err");
                    }
                }

                await _outputService.Output(ViewModelBuilder.PresentStack(context.CalculationData));
                input = await _inputService.GetInput();
            }
        }
    }
}
