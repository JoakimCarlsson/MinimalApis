namespace MinimalApis.Features.Car.Get;

public class GetCar : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/car/{Id}", GetCarHandler)
            .WithDisplayName("Get Car")
            .WithName("Car")
            .WithDescription("Get a car by Id")
            .WithOpenApi(o =>
            {
                o.Description = "Get a car by Id";
                return o; 
            });

        app.MapGet("Cache", () => DateTime.Now)
            .CacheOutput();

        app.MapGet("NoCache", () => DateTime.Now);
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