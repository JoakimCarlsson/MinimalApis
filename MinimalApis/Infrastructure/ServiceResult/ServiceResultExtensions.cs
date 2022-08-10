namespace MinimalApis.Infrastructure.ServiceResult;

public static class ServiceResultExtensions
{
    public static IResult ToResult<T>(this ServiceResult<T> result)
    {
        return result switch
        {
            SuccessServiceResult<Foo> success => TypedResults.Ok(),
            FailureServiceResult<Foo> badRequest => TypedResults.BadRequest(),
            NotFoundServiceResult<Foo> notFound => TypedResults.NotFound(),
            _ => TypedResults.Problem()
        };
    }
}