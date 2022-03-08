namespace Archable.Application.Interfaces.Providers
{
    public interface IStorageProvider
    {
        int Count { get; }

        Result Stash(object key, object value);
        Result Delete(object key);
        Result<object> Fetch(object key);
    }
}