using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp
{
    public static class LoggingMiddlewareExtension
    {
        public static void UseLoggintMiddleware(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseMiddleware<LoggintMiddleware>();
        }
    }

    public class LoggintMiddleware
    {
        public LoggintMiddleware(RequestDelegate next, ILogger<LoggintMiddleware> logger)
        {
            this.next = next;
            this.Logger = logger;
        }
        private readonly RequestDelegate next;
        public ILogger<LoggintMiddleware> Logger { get; set; }
        public async Task Invoke(HttpContext httpcontext)
        {
            var header = httpcontext.Request.Headers["Accept-Encoding"];
            //Console.WriteLine(header);
            Logger.LogInformation($"{DateTime.Now} accept-encodeing = {header}");

            await next.Invoke(httpcontext);
        }
    }
}
