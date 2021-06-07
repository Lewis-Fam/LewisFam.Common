namespace LewisFam.Interfaces
{
    public interface IMetaData<out TEntity> where TEntity : new()
    {
        TEntity[] Data { get; }
    }
}
