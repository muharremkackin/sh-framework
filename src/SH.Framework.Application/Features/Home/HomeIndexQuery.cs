using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SH.Framework.Application.Common.Cqrs;
using SH.Framework.Library.Cqrs;

namespace SH.Framework.Application.Features.Home;

public class HomeIndexQuery
{
    public class Query : Request<Response>;

    public record Response(string Version);
    
    public class Handler : RequestHandler<Query, Response>
    {
        public override async Task<Result<Response>> HandleAsync(Query request, CancellationToken cancellationToken = new())
        {
            return Result.Success(new Response(Version()));
        }
    }

    public static void Endpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", async ([AsParameters] Query query, [FromServices] IProjector projector) =>
        {
            var result = await projector.SendAsync(query);

            return Results.Ok(result);
        });
    }

    private static string Version()
    {
        var assembly = Assembly.GetEntryAssembly();
        return assembly?.GetName().Version?.ToString() ?? "0.0.0";
    }
}