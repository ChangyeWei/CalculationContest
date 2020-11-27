using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CalculatorDemo.Application.Models;

namespace CalculatorDemo.Application.ApplicationService.Interface
{
    public interface IInputFormatService
    {
        Task<List<InputDto>> GetInput();
    }
}
