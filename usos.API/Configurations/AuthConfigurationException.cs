using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace usos.API.Configurations
{
    public static class AuthConfigurationExtension
    {
        /// <summary>
        /// Auth configuration default implementation.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.LoginPath = "/auth/login";
                option.Cookie.Name = "UsosCookie";
                option.ExpireTimeSpan = TimeSpan.Parse(configuration["Auth:CookieExpirationTimeSpan"]);
                option.Events.OnRedirectToLogin = UnAuthorizedResponse;
                option.Events.OnRedirectToAccessDenied = AccessDeniedResponse;
                option.Cookie.SameSite = SameSiteMode.None;
            });

            return services;
        }
    
        private static Task UnAuthorizedResponse(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
            return Task.CompletedTask;
        }
    
        private static Task AccessDeniedResponse(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
            return Task.CompletedTask;
        }
    }
}