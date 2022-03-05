namespace Archable.Application.Models.Results
{
    public class Result
    {
        public bool Success { get; init; }
        public bool Failure => !Success;
        public string? Error { get; init; }

        protected Result(bool success, string error)
        {
            if(!success && error == string.Empty)
            {
                throw new InvalidOperationException();
            }

            this.Success = success;
            this.Error = error;
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>(default!, false, message);
        }

        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }
    }

    public class Result<T> : Result
    {
        protected internal Result(T value, bool success, string error)
            : base(success, error)
        {
            this.Value = value;
        }

        public T Value { get; init; }
    }
}