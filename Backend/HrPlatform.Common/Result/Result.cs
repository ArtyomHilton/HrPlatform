namespace HrPlatform.Common.Result;

public class Result<T>
{
    private bool _result { get; set; }

    public bool IsSuccess => _result;
    public bool IsFailed => !_result;

    public T Value { get; init; }

    public IError? Error { get; init; }

    private Result(T value, IError? error, bool result)
    {
        Error = error;
        Value = value;
        _result = result;
    }

    public static Result<T> Success(T value) => 
        new Result<T>(value, null, true);

    public static Result<T> Failed(T value, IError error) =>
        new Result<T>(value, error, false);
}
