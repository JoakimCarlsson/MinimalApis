namespace MinimalApis.TypedHttpClients;

public class DummyApiHttpClientDelegationHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);
        Console.WriteLine($"{request.Method} {request.RequestUri} {response.StatusCode}");
        return response;
    }
}