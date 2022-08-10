namespace MinimalApis.Infrastructure.ServiceResult;

public abstract record ServiceResult<T>
{
    public static SuccessServiceResult<T> Success(T data) => new SuccessServiceResult<T>(data);
    public static FailureServiceResult<T> Failure(string message) => new FailureServiceResult<T>(message);
    public static NotFoundServiceResult<T> NotFound(string message) => new NotFoundServiceResult<T>(message);
}

public record NotFoundServiceResult<T>(string Message) : ServiceResult<T>;

public record FailureServiceResult<T>(string Message) : ServiceResult<T>;

public record SuccessServiceResult<T>(T Data) : ServiceResult<T>;
