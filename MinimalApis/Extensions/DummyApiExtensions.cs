using MinimalApis.Services;
using MinimalApis.TypedHttpClients;

namespace MinimalApis.Extensions;

public static class DummyApiExtensions
{
    public static IServiceCollection AddDummyApi(this IServiceCollection services)
    {
        services.AddTransient<IDummyApiService, DummyApiService>();
        
        services.AddHttpClient<DummyApiHttpClient>(o =>
        {
            o.BaseAddress = new Uri("https://dummyapi.io/", UriKind.Absolute);
            o.DefaultRequestHeaders.Add("app-id", "62f3abf7744cbf6f79e46ff9");
        });
        return services;
    }
}