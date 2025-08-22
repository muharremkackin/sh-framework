using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SH.Framework.Library.Cqrs;

namespace SH.Framework.Application;

public static class RegisterApplication
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddCqrsLibraryConfiguration(Assembly.GetExecutingAssembly());  
    } 
}