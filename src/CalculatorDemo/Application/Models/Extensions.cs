using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorDemo.Application.SeedWork
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
        {
            if (items == null || !items.Any())
                return true;
            return false;
        }
    }
}
