namespace LewisFam.Data.MetaData
{
    public interface IMetaData<out T> where T : new()
    {
        T MetaData { get; }
    }
}
