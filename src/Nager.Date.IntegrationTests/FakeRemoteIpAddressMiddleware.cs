using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Nager.Date.IntegrationTests
{
    public class FakeRemoteIpAddressMiddleware
    {
        private readonly RequestDelegate _next;
        public static IPAddress _testNet2IP = IPAddress.Parse("198.51.100.3");
        public virtual IPAddress FakeIpAddress { get; } = _testNet2IP;

        public FakeRemoteIpAddressMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Connection.RemoteIpAddress = this.FakeIpAddress;
            await this._next(httpContext);
        }
    }

    public class FakeLocalhostIPMiddleware : FakeRemoteIpAddressMiddleware
    {
        public override IPAddress FakeIpAddress => IPAddress.Parse("::1");
        public FakeLocalhostIPMiddleware(RequestDelegate next) : base(next) { }
    }

    public class CustomStartupFilter<TFakeIpAddressMiddleware> : IStartupFilter where TFakeIpAddressMiddleware: FakeRemoteIpAddressMiddleware 
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware(typeof(TFakeIpAddressMiddleware));
                next(app);
            };
        }
    }
}
