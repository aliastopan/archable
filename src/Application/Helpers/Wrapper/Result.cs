namespace Archable.Application.Helpers.Wrapper
{
    public class Result
    {
        public bool Success { get; init; }
        public bool Failure => !Success;
        public Exception? Exception { get; init; }
        public string Verdict
        {
            get => Exception is null
                ? "OK."
                : Exception.Message;
        }

        protected Result(bool success, Exception exception)
        {
            if(!success && exception is null)
            {
                throw new InvalidOperationException();
            }

            this.Success = success;
            this.Exception = exception;
        }

        public static Result Fail(Exception exception)
        {
            return new Result(false, exception);
        }

        public static Result<TValue> Fail<TValue>(Exception exception)
        {
            return new Result<TValue>(default!, false, exception);
        }

        public static Result Ok()
        {
            return new Result(true, null!);
        }

        public static Result<TValue> Ok<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, null!);
        }
    }

    public class Result<TValue> : Result
    {
        protected internal Result(TValue value, bool success, Exception exception)
            : base(success, exception)
        {
            this.Value = value;
        }

        public TValue Value { get; init; }
    }
}