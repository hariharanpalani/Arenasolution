using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ASPNetCore.Sample
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder builder)
        {
            builder.Use((httpContext, next) =>
            {
                if (httpContext.Request.Path.HasValue && httpContext.Request.Path.Value == "/show")
                {
                    return next();
                }

                httpContext.Response.StatusCode = 404;
                return httpContext.Response.WriteAsync("Not found!!!");
            });

            builder.Use((httpContext, next) =>
            {
                return httpContext.Response.WriteAsync("Hello welcome!!!!");
            });
        }
    }
}