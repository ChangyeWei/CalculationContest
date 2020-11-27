using CalculatorDemo.Application.DomainService.ApplicationOperation;
using CalculatorDemo.Application.SeedWork;

namespace CalculatorDemo.Application.Domain
{
    public class ApplicationOperationType : Enumeration
    {
        public static ApplicationOperationType Input = new ApplicationOperationType(0, nameof(Input).ToLowerInvariant(), null);
        public static ApplicationOperationType Undo = new ApplicationOperationType(1, nameof(Undo).ToLowerInvariant(), new UndoOperation(nameof(Undo).ToLowerInvariant()));
        public static ApplicationOperationType Clear = new ApplicationOperationType(2, nameof(Clear).ToLowerInvariant(), new ClearOperation(nameof(Clear).ToLowerInvariant()));

        protected ApplicationOperationType(int id, string name, IApplicationOperation applicationOperation) : base(id, name)
        {
            ApplicationOperation = applicationOperation;
        }

        public IApplicationOperation ApplicationOperation { get; private set; }
    }
}
