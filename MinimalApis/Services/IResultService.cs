using MinimalApis.Infrastructure.ServiceResult;

namespace MinimalApis.Services;

public interface IResultService
{
    public ServiceResult<Foo> GetResult();
}

public class ResultService : IResultService
{
    public ServiceResult<Foo> GetResult()
    {
        return ServiceResult<Foo>.Failure("Error");
    }
}

public sealed record Foo(string Name, int Age);