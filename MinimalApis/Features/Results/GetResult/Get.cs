using MinimalApis.Infrastructure.ServiceResult;

namespace MinimalApis.Features.Results.GetResult;

public class Get : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/getResult", GetResult);
    }

    private async Task<IResult> GetResult([FromServices] IResultService resultService)
    {
        var result = resultService.GetResult();
        return result.ToResult();
    }
}