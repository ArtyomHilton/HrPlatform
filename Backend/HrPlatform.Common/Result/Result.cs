using HrPlatform.Common.Result.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrPlatform.Common.Result;

public class Result
{
    private bool _result { get; init; }
    public bool IsSuccess => _result;
    public bool IsFailed => !_result;

    public ErrorBase? Error { get; init; }

    public Result(ErrorBase? error, bool result)
    {
        _result = result;
        Error = error;
    }

    public static Result Success() =>
        new Result(default, true);

    public static Result Failed(ErrorBase error) =>
        new Result(error, false);
}

public class Result<T> : Result
{
    public T? Value { get; init; }

    private Result(T? value, ErrorBase? error, bool result) : base(error, result)
    {
        Value = value;
    }

    public static Result<T> Success(T value) =>
        new Result<T>(value, default, true);

    public static new Result<T> Failed(ErrorBase error) =>
        new Result<T>(default, error, false);
}