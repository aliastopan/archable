using System.Collections;

namespace Archable.Infrastructure.Services
{
    internal sealed class MockStorageService : IStorageProvider
    {
        private readonly Hashtable _storage;

        public int Count => _storage.Count;

        public MockStorageService()
        {
            _storage = new Hashtable();
        }

        public Result Stash(object key, object value)
        {
            var hasDuplicate = _storage.ContainsKey(key);

            return hasDuplicate
                ? Exception()
                : Stash();

            #region LOCAL FUNCTION
            Result Stash()
            {
                _storage.Add(key, value);
                return Result.Ok();
            }

            Result Exception()
            {
                string message = $"Duplicate Found: record of KEY: '{key}' already exist exception.";
                var exception = new Exception(message);

                return Result.Fail(exception);
            }
            #endregion
        }

        public Result Delete(object key)
        {
            var keyFound = _storage.ContainsKey(key);

            return !keyFound
                ? Exception()
                : Delete();

            #region LOCAL FUNCTION
            Result Delete()
            {
                _storage.Remove(key);
                return Result.Ok();
            }

            Result Exception()
            {
                return Result.Fail(
                    new Exception($"Not Found: record of KEY: '{key}' exception.")
                );
            }
            #endregion
        }

        public Result<object> Fetch(object key)
        {
            var keyFound = _storage.ContainsKey(key);

            return !keyFound
                ? Exception()
                : Fetch();

            #region LOCAL FUNCTION
            Result<object> Fetch()
            {
                return Result.Ok<object>(_storage[key]!);
            }

            Result<object> Exception()
            {
                return Result.Fail<object>(
                    new Exception($"Not Found: record of KEY: '{key}' exception.")
                );
            }
            #endregion
        }
    }
}