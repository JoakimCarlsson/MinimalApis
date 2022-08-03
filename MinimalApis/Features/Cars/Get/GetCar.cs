namespace MinimalApis.Features.Cars.Get;

public class GetCar : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        var car = app.MapGroup("/car")
            .WithTags("My Tag")
            .WithSummary("I am a summary")
            .WithOpenApi();

        car.MapGet("/{Id}", GetCarHandler);

        car.MapGet("cache", () => DateTime.Now)
            .CacheOutput();

        car.MapGet("noCache", () => DateTime.Now);
    }

    private async Task<Results<NoContent, NotFound, BadRequest, UnauthorizedHttpResult>> GetCarHandler([AsParameters] SearchRequest searchRequest)
    {
        searchRequest.Logger.LogInformation("Car Id: {Id}", searchRequest.Id);
        searchRequest.Logger.LogInformation("Car Colour: {Colour}", searchRequest.Colour);
        return TypedResults.NoContent();
    }

    private record struct SearchRequest(
        [FromRoute] int Id,
        [FromQuery] string Colour,
        [FromServices] ILogger<GetCar> Logger
        // [FromBody] string CarMake,
        // [FromHeader] string Authorization
        );
}