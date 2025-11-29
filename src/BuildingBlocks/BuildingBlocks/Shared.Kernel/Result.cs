using System.Net;

namespace BuildingBlocks.Shared.Kernel;
public class Result<T> where T : class
{
    public HttpStatusCode IsSuccess { get; }
    public string? Error { get; }
    public T? Value { get; }

    private Result(HttpStatusCode isSuccess, T? value, string? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Success(T value) => new(HttpStatusCode.OK, value, null);
    public static Result<T> Failure(string error) => new(HttpStatusCode.BadRequest, default, error);
    public static Result<T> Failure(HttpStatusCode statusCode, string error) => new(HttpStatusCode.BadRequest, default, error);

}
