using Microsoft.Extensions.DependencyInjection;
using BlogBackend.Application.Interfaces;
using BlogBackend.Application.Services;

namespace BlogBackend.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IChatService, ChatService>();

            return services;
        }
    }
} 