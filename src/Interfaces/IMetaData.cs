/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Author: LewisFam
***/

namespace LewisFam.Interfaces
{
    public interface IMetaData<out TEntity> where TEntity : new()
    {
        TEntity[] Data { get; }
    }
}