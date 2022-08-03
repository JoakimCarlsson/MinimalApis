namespace MinimalApis.Features.Car.Get;

public class GetCar : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/car/{Id}", GetCarHandler)
            .WithName("Car")
            .WithOpenApi()
            .WithDescription("Get a car by id");
    }

    private async Task<Results<NoContent, NotFound, BadRequest, UnauthorizedHttpResult>> GetCarHandler([AsParameters] SearchRequest searchRequest)
    {
        searchRequest.logger.LogInformation("Car Id: {Id}", searchRequest.Id);
        searchRequest.logger.LogInformation("Car Colour: {Colour}", searchRequest.Colour);
        return TypedResults.NoContent();
    }

    private record struct SearchRequest(
        [FromRoute] int Id,
        [FromQuery] string Colour,
        [FromServices] ILogger<GetCar> logger
        // [FromBody] string CarMake,
        // [FromHeader] string Authorization
        );
}