namespace MinimalApis.TypedHttpClients;

public class DummyApiHttpClient
{
    private readonly HttpClient _httpClient;
    private static readonly Uri UserListUri = new("data/v1/user", UriKind.Relative);
    
    public DummyApiHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<UserList?> GetUserListAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(UserListUri, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UserList>(cancellationToken: cancellationToken);
        }

        return null;
    }
}