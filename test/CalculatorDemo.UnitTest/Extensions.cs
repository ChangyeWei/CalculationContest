using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.Language;
using Moq.Language.Flow;

namespace CalculatorDemo.UnitTest
{
    public static class Extensions
    {
        public static void ReturnsInOrder<T, TResult>(this ISetup<T, TResult> setup,
            params TResult[] results) where T : class
        {
            setup.Returns(new Queue<TResult>(results).Dequeue);
        }

        public static IReturnsResult<TMock> ReturnsInOrderAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, params TResult[] results) where TMock : class
        {
            var queue = new Queue<TResult>(results);
            return mock.ReturnsAsync(() => queue.Dequeue());
        }
    }
}
