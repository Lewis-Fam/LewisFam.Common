/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Author: LewisFam
***/

namespace LewisFam.Interfaces
{
    public interface IRequest<TResponse>
    {
        public IResponse<TResponse> Response { get; }
    }

    public interface IResponse : IResult
    {
    }

    public interface IResponse<out T> : IResponse
    {
        //T[] MetaData { get; }
    }
}