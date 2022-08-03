namespace MinimalApis.Extensions;

public static class EndpointMapper
{
    public static void MapEndpointsInAssembly(this WebApplication app, Assembly assembly)
    {
        var endpoints = assembly.GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IEndpoint)) && t.IsClass)
            .Select(t => Activator.CreateInstance(t) as IEndpoint).ToList();

        if (endpoints.Any() is false)
            throw new ArgumentNullException(nameof(endpoints), "No endpoints found in assembly");

        foreach (var endpoint in endpoints)
        {
            endpoint?.MapEndpoint(app);
        }
    }
}