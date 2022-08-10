namespace MinimalApis.Infrastructure.ServiceResult;

public abstract class ServiceResult<T>
{
    public static SuccessServiceResult<T> Success(T entity) => new(entity);
    public static FailureServiceResult<T> Failure(string message) => new(message);
    public static NotFoundServiceResult<T> NotFound(string? message) => new(message);
} 

public class NotFoundServiceResult<T> : ServiceResult<T>
{
    public string? Message { get; }

    public NotFoundServiceResult(string? message)
    {
        Message = message;
    }
}

public class FailureServiceResult<T> : ServiceResult<T>
{
    public string Message { get; }

    internal FailureServiceResult(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentNullException(nameof(message), "Message cannot be null or empty when creating a FailureServiceResult");

        Message = message;
    }
}

public class SuccessServiceResult<T> : ServiceResult<T>
{
    public T Entity { get; }
    
    internal SuccessServiceResult(T entity)
    {
        Entity = entity;
    }
}