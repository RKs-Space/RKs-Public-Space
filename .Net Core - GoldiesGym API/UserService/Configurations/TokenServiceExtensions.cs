using Microsoft.Extensions.DependencyInjection;
using System;

namespace UserService.Configurations
{
    /*
     * The class provides extension method for registering and providing options for TokenGenerator service
     * 
     */

    public static class TokenServiceExtensions
    {
        public static IServiceCollection AddTokenService(this IServiceCollection serviceCollection, Action<TokenOptions> options)
        {
            throw new NotImplementedException();
        }
    }
}
