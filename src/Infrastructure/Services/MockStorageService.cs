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
            var hasKey = _storage.ContainsKey(key);

            if(hasKey)
            {
                var message = $"Duplicate Found: record of KEY: '{key}' already exist exception.";
                var exception = new Exception(message);

                return Result.Fail(exception);
            }
            else
            {
                _storage.Add(key, value);

                return Result.Ok();
            }
        }

        public Result Delete(object key)
        {
            var hasKey = _storage.ContainsKey(key);

            if(!hasKey)
            {
                var message = $"Not Found: record of KEY: '{key}' exception.";
                var exception = new Exception(message);

                return Result.Fail(exception);
            }
            else
            {
                return Result.Ok();
            }
        }

        public Result<object> Fetch(object key)
        {
            var hasKey = _storage.ContainsKey(key);

            if(!hasKey)
            {
                var message = $"Not Found: record of KEY: '{key}' exception.";
                var exception = new Exception(message);

                return Result.Fail<object>(exception);
            }
            else
            {
                return Result.Ok<object>(_storage[key]!);
            }
        }
    }
}