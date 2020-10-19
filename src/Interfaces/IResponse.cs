namespace LewisFam.Common.Interfaces
{
    public interface IResponse : IResult
    {
    }

    public interface IResponse<out T> : IResponse
    {
        T MetaData { get; }
    }
}