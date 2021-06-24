/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

namespace LewisFam.Interfaces
{
    public partial interface IRequest<out TResponse>
    {
        public IResponse<TResponse> Response { get; }
    }

    public partial interface IResponse : IResult
    {
    }

    public partial interface IResponse<out T> : IResponse
    {
        //T[] MetaData { get; }
    }
}