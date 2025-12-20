using HrPlatform.Common.Result.Errors;

namespace HrPlatform.Common.Result;

public class Result<T>
{
    private bool _result { get; init; }
    public bool IsSuccess => _result;
    public bool IsFailed => !_result;

    public ErrorBase? Error { get; init; }
    public T? Value { get; init; }

    private Result(T? value, ErrorBase? error, bool result)
    {   
        Value = value;
        _result = result;
        Error = error;
    }

    public static Result<T> Success(T value) => 
        new Result<T>(value, default, true);

    public static Result<T> Failed(ErrorBase error) =>
        new Result<T>(default, error, false);
}