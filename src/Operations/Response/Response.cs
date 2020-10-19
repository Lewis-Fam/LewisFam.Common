using LewisFam.Common.Interfaces;
using System;

namespace LewisFam.Common.Operations
{
    /// <summary>
    /// Internal use only. 
    /// </summary>
    /// <seealso cref="IOperationResponse" />
    public abstract class Response : IOperationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        protected Response() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected Response(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Returns true if MetaData is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsValid => MetaData != null;     
        
        /// <summary>
        /// Meta Data
        /// </summary>
        public virtual object MetaData { get; set; }

        /// <summary>
        /// Sets the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected void SetId(Guid id)
        {
            Id = id;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IResponseOperation" />
    public class Response<T> : Response, IOperationResponse<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class.
        /// </summary>
        protected Response() : base()
        {   
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected Response(Guid id) : base(id)
        {
            Id = id;
        }

        /// <summary>
        /// Returns true if MetaData is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public new virtual bool IsValid => MetaData != null;

        /// <summary>
        /// Meta Data
        /// </summary>
        public new T MetaData { get; set; }        
    }
}