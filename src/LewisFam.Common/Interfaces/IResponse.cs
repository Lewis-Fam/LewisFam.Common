namespace LewisFam.Interfaces
{
    public interface IResponse : IResult
    {
    }

    public interface IRequest<TResponse>
    {
        public IResponse<TResponse> Response { get;}


    }

    public interface IResponse<out T> : IResponse
    {
        //T[] MetaData { get; }
    }
}