using LewisFam.Common.Interfaces;
using System;

namespace LewisFam.Common.Operations
{
    public class OperationResponse : Response, IResponse
    {
        public OperationResponse() : base()
        {
        }

        public OperationResponse(Guid id) : base(id)
        {
        }
    }

    public class OperationResponse<T> : Response<T>, IResponse<T> where T : new()
    {
        public OperationResponse() : base()
        {
        }

        public OperationResponse(Guid id) : base(id)
        {
        }
    }
}