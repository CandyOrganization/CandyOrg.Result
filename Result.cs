using CandyOrg.Result.Abstractions;

namespace CandyOrg.Result;

public class Result<T>
{
    public T? Value { get; set; }
    public bool IsSuccess { get; set; }
    public BaseError? Error { get; set; }
    public ErrorCode Code { get; set; }

    public static Result<T> Success(T? data = default) => new () { IsSuccess = true, Value = data };
    public static Result<T> ValidationError(BaseError error, T? data = default) => Fail(error, ErrorCode.Validation, data);
    public static Result<T> NotFoundError(BaseError error, T? data = default) => Fail(error, ErrorCode.NotFound, data);
    public static Result<T> ForbiddenError(BaseError error, T? data = default) => Fail(error, ErrorCode.Forbidden, data);
    public static Result<T> UnauthorizedError(BaseError error, T? data = default) => Fail(error, ErrorCode.Unauthorized, data);
    private static Result<T> Fail(BaseError error, ErrorCode code, T? value = default) => new ()
    {
        IsSuccess = false,
        Error = error,
        Code = code,
        Value = value
    };
}