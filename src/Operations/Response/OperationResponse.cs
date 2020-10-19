using System;

namespace LewisFam.Common.Operations
{
    public class OperationResponse : Response, IOperationResponse
    {
        public OperationResponse() : base()
        {
        }

        public OperationResponse(Guid id) : base(id)
        {
        }
    }

    public class OperationResponse<T> : Response<T>, IOperationResponse<T>
    {
        public OperationResponse() : base()
        {
        }

        public OperationResponse(Guid id) : base(id)
        {
        }
    }
}