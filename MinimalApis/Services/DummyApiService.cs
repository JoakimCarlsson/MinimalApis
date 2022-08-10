namespace MinimalApis.Services;

public class DummyApiService : IDummyApiService
{
    private readonly DummyApiHttpClient _dummyApiHttpClient;

    public DummyApiService(DummyApiHttpClient dummyApiHttpClient)
    {
        _dummyApiHttpClient = dummyApiHttpClient;
    }

    public async Task GetUsers(CancellationToken cancellationToken = default)
    {
        var users = await _dummyApiHttpClient.GetUserListAsync(cancellationToken);
    }
}