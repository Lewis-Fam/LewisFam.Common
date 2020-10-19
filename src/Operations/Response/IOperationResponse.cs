﻿
using LewisFam.Common.Interfaces;
using System;

namespace LewisFam.Common.Operations
{
    /// <summary>
    /// The operation response.
    /// </summary>
    public interface IOperationResponse : IResponse
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        Guid Id { get;  }
        /// <summary>
        /// Gets a value indicating whether is valid.
        /// </summary>
        bool IsValid { get; }
        /// <summary>
        /// Gets or sets the meta data.
        /// </summary>
        object MetaData { get; set; }
    }

    /// <summary>
    /// The operation response.
    /// </summary>
    public interface IOperationResponse<T> : IResponse<T>
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        new Guid Id { get; }
        /// <summary>
        /// Gets a value indicating whether is valid.
        /// </summary>
        new bool IsValid { get; }
        /// <summary>
        /// Gets or sets the meta data.
        /// </summary>
        new T MetaData { get; set; }
    }
}