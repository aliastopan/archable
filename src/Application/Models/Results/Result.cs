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

        public static Result<TValue> Fail<TValue>(string message)
        {
            return new Result<TValue>(default!, false, message);
        }

        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }

        public static Result<TValue> Ok<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, string.Empty);
        }
    }

    public class Result<TValue> : Result
    {
        protected internal Result(TValue value, bool success, string error)
            : base(success, error)
        {
            this.Value = value;
        }

        public TValue Value { get; init; }
    }
}