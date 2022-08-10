namespace MinimalApis.Features.DummyApi.GetAll;

public class GetAll : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/dummy", GetAllUsers)
            .WithOpenApi();
    }

    private async Task<Results<Ok, BadRequest>> GetAllUsers([FromServices] IDummyApiService dummyApiService, CancellationToken cancellationToken)
    {
        await dummyApiService.GetUsers(cancellationToken);
        return TypedResults.Ok();
    }
}