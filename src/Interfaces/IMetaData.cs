/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Author: LewisFam
***/

namespace LewisFam.Interfaces
{
    /// <summary>
    /// The meta data.
    /// </summary>
    public partial interface IMetaData<out TEntity> where TEntity : new()
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        TEntity[] Data { get; }
    }
}