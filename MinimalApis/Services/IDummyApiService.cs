namespace MinimalApis.Services;

public interface IDummyApiService
{
    public Task GetUsers(CancellationToken cancellationToken = default);
}