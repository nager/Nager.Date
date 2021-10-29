using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nager.Date.Website.Middleware
{
    public class AllowApiAccessMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApiKeyLookup _apiKeyLookup;
        private readonly bool _isDev;
        private readonly TimeSpan _keepAlive;

        public AllowApiAccessMiddleware(RequestDelegate next, IOptions<AllowApiAccessOptions> options, IApiKeyLookup apiKeyLookup, IWebHostEnvironment env)
        {
            this._next = next;
            this._apiKeyLookup = apiKeyLookup;
            this._keepAlive = TimeSpan.FromSeconds(options.Value?.APIKeyBypassSeconds ?? 10);
            this._isDev = env.IsDevelopment();
        }

        internal const string MvcPageRequestedKey = "mvc_page_requested";
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.Value != null && httpContext.Request.Path.Value.StartsWith("/Api/", StringComparison.OrdinalIgnoreCase))
            {
                if (httpContext.Request.Query.TryGetValue("api_key", out var keys))
                {
                    if (await this._apiKeyLookup.IsValidKey(keys.Single(), httpContext.Connection.RemoteIpAddress))
                    {
                        await this._next(httpContext);
                        return;
                    }
                    await WriteErrorAsync(httpContext.Response, "invalid api_key", StatusCodes.Status401Unauthorized);
                    return;
                }
                if (httpContext.User.Identity.IsAuthenticated)
                {
                    // it could be argued that it is only requests with an api_key we wish to track
                    // however, this would provide a back door into the app for unrestricted use
                    // plus it is useful on the development server 
                    _ = this._apiKeyLookup.AddHit(httpContext.User, httpContext.Connection.RemoteIpAddress);
                    await this._next(httpContext);
                    return;
                }
                if (!httpContext.Request.Headers.TryGetValue("Origin", out var origin))
                {
                    if (!httpContext.Request.Headers.TryGetValue("Referer", out origin)) {
                        await WriteErrorAsync(httpContext.Response,
                            "Request is missing both Origin and Referer headers");
                        return;
                    }
                }
                // we could use host to strip out port, however for testing on a localhost
                // it is easier to send CORS requests from another port and have them treated as CORS requests
                // of course down side is the port is not going to be constant in every development environment
                var authority = new Uri(origin.ToString().ToLowerInvariant()).Authority;
                
                var currentAuthority = this._isDev ? "localhost:44389"
                                                :"date.nager.at";
        
                if (authority == currentAuthority &&
                    httpContext.Session.TryGetDateTime(MvcPageRequestedKey, out var timestamp))
                {
                    var elapsed = DateTime.UtcNow - timestamp;
                    if (elapsed.Ticks > 0 && elapsed <= this._keepAlive)
                    {
                        await this._next(httpContext);
                        return;
                    }
                    await WriteErrorAsync(httpContext.Response,
                        "Too much time between page request and subsequent API request",
                        StatusCodes.Status410Gone);
                    return;
                }
                await WriteErrorAsync(httpContext.Response,
                    "missing query parameter api_key",
                    StatusCodes.Status401Unauthorized);
                return;
            }
            await this._next(httpContext);
        }
        private static Task WriteErrorAsync(HttpResponse response, string message, int statusCode = StatusCodes.Status400BadRequest)
        {
            response.StatusCode = statusCode;
            response.ContentType = "text/plain";
            return response.WriteAsync(message);
        }
    }
    internal static class SessionExtensions
    {
        public static bool TryGetDateTime(this ISession session, string key, out DateTime value)
        {
            if (session.TryGetValue(key, out var dateBytes))
            {
                value = new DateTime(BitConverter.ToInt64(dateBytes));
                return true;
            }
            value = default;
            return false;
        }
        public static void SetDateTime(this ISession session, string key, DateTime value)
        {
            var dateBytes = BitConverter.GetBytes(value.Ticks);
            session.Set(key, dateBytes);
        }
    }

    public static class AllowApiAccessExtensions
    {
        /// Call UseAllowApiAccessOptions after UseAuthentication and before UseEndpoints
        public static IApplicationBuilder UseAllowApiAccess(this IApplicationBuilder builder)
        {
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-5.0
            // Call UseSession after UseRouting and before UseEndpoints
            builder.UseSession();
            return builder.UseMiddleware<AllowApiAccessMiddleware>();
        }

        public static IServiceCollection AddAllowApiAccess(this IServiceCollection services, double timoutSeconds = 10)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor;
                options.RequireHeaderSymmetry = false;
                options.ForwardLimit = null;
            });

            
            services.AddDistributedMemoryCache();
            var timeout = TimeSpan.FromSeconds(timoutSeconds);
            services.AddSession(options =>
            {
                options.IdleTimeout = timeout;
                options.IOTimeout = timeout;
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });
            services.AddSingleton<IApiKeyLookup, Context.ApiKeyManagement>();
            return services;
        }
    }
}
