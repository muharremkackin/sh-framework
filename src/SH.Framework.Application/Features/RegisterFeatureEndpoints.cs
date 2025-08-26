using Microsoft.AspNetCore.Routing;
using SH.Framework.Application.Features.Authentication;
using SH.Framework.Application.Features.Home;

namespace SH.Framework.Application.Features;

public static class RegisterFeatureEndpoints
{
    public static void MapFeatureEndpoints(this IEndpointRouteBuilder endpoints)
    {
        HomeIndexQuery.Endpoint(endpoints);
        
        AuthenticationLoginCommand.Endpoint(endpoints);
    }
}