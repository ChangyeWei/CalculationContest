using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorDemo.Application.ApplicationService.Interface
{
    public interface IOutputService
    {
        Task Output(string msg);
    }
}
