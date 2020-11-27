using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorDemo.Application.ApplicationService
{
    public static class ViewModelBuilder
    {
        public static string PresentStack(Stack<decimal> stack)
        {
            StringBuilder stringBuilder =new StringBuilder();
            stringBuilder.Append("stack: ");
            for (var index = stack.Count - 1; index > -1; index--)
            {
                stringBuilder.Append(stack.ElementAtOrDefault(index).FormatDecimal() + " ");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        private static string FormatDecimal(this decimal value)
        {
            var valueString = value.ToString();
            var valueArray = valueString.Split(".");
            if (valueArray.Length == 1)
            {
                return valueString;
            }

            if (valueArray[1].Length <= 10)
            {
                return valueString;
            }

            return $"{valueArray[0]}.{valueArray[1].Substring(0, 10)}";
        }

    }
}
