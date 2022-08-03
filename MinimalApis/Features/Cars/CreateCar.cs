namespace MinimalApis.Features.Cars;

public class CreateCar : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPost("/car", CreateCarHandler);
    }

    private async Task<Results<Ok, BadRequest>> CreateCarHandler(
        [FromBody] CreateCarRequest request,
        [FromServices] ApplicationDbContext dbContext, 
        [FromServices] ILogger<CreateCar> logger)
    {
        try
        {
            var car = new Car
            {
                Make = request.Make,
                Model = request.Model
            };

            await dbContext.Cars.AddAsync(car);
            await dbContext.SaveChangesAsync();

            return TypedResults.Ok();
        }
        catch (Exception e)
        {
            logger.LogCritical("Could not create car & save it to the DB {e}", e.Message);
            return TypedResults.BadRequest();
        }
    }

    private record struct CreateCarRequest
    {
        public string Make { get; init; }
        public string Model { get; init; }
    }
}