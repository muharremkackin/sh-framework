using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using SH.Framework.Application.Common.Authentication;
using SH.Framework.Application.Common.Extensions;
using SH.Framework.Library.Cqrs;
using SH.Framework.Library.Cqrs.Implementation;

namespace SH.Framework.Application.Features.Authentication;

public class AuthenticationLoginCommand
{
    public class Command : Request<Response>;
    public record Response(string Token);
    
    public class Handler(IOptions<AuthenticationOptions> options) : RequestHandler<Command, Response>
    {
        public override async Task<Result<Response>> HandleAsync(Command request, CancellationToken cancellationToken = new CancellationToken())
        {
            return Result.Success(new Response(
                TokenBuilder.Instance()
                    .WithIssuer(options.Value.ValidIssuers.First())
                    .WithAudience(options.Value.ValidAudiences.First())
                    .WithSecret(Encoding.UTF8.GetBytes(options.Value.IssuerSigningKey))
                    .WithExpiration(DateTime.UtcNow.AddDuration(options.Value.Expiration))
                    .WithNotBefore(DateTime.UtcNow.AddDuration(options.Value.NotBefore))
                    .Build()
                ));
        }
    }

    public static void Endpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/v1/authentication/login",
            async ([FromBody] Command command, [FromServices] IProjector projector) =>
            {
                var result = await projector.SendAsync(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });
    }
    
}