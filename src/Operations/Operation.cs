using System;

namespace LewisFam.Common.Operations
{
    public interface IMyOperation
    {
        Guid OperationId { get; }
    }

    public interface IMyOperationTransient : IMyOperation
    {
    }

    public interface IMyOperationScoped : IMyOperation
    {
    }

    public interface IMyOperationSingleton : IMyOperation
    {
    }

    public interface IMyOperationSingletonInstance : IMyOperation
    {
    }

    public class Operation : IMyOperationTransient,
    IMyOperationScoped,
    IMyOperationSingleton,
    IMyOperationSingletonInstance
    {
        public Operation() : this(Guid.NewGuid())
        {
        }

        public Operation(Guid id)
        {
            OperationId = id;            
        }

        public Guid OperationId { get; private set; }        
    }
}
