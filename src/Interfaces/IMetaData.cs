/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

namespace LewisFam.Interfaces
{
    public interface IDescriptable : INameable
    {
        string Description { get; set; }

        string Name { get; set; }
    }

    public interface IMessage
    {
        bool HasMessage { get; }

        string Message { get; }
    }

    /// <summary>The meta data.</summary>
    public partial interface IMetaData<out TEntity> where TEntity : new()
    {
        /// <summary>Gets the data.</summary>
        TEntity[] Data { get; }
    }

    public interface INameable
    {
        string Name { get; }
    }
}