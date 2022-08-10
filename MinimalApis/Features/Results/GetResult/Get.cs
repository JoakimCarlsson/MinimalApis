using MinimalApis.Infrastructure.ServiceResult;

namespace MinimalApis.Features.Results.GetResult;

public class Get : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/getResult", GetResult);
    }

    private async Task<Results<Ok, BadRequest, NotFound>> GetResult([FromServices] IResultService resultService)
    {
        var result = resultService.GetResult();
        if (result is SuccessServiceResult<Foo> success)
        {
            return TypedResults.Ok();
        }

        if (result is FailureServiceResult<Foo> badRequest)
        {
            return TypedResults.BadRequest();
        }

        if (result is NotFoundServiceResult<Foo> notFound)
        {
            return TypedResults.NotFound();
        }

        return null;
    }
}