using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp
{
    public static class CustomMiddlwareExtension
    {
        public static void UseCustomMiddleWare(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseMiddleware<CustomMIddleware>();
        }
    }

    public class CustomMIddleware
    {
        public CustomMIddleware(RequestDelegate next, ILogger<CustomMIddleware> logger)
        {
            this.Next = next;
            this.Logger = logger;
        }
        public RequestDelegate Next { get; set; }
        public ILogger<CustomMIddleware> Logger { get; set; }
        public async Task Invoke(HttpContext httpcontext)
        {
            var header = httpcontext.Request.Headers["Accept-Encoding"];
            //Console.WriteLine(header);
            Logger.LogInformation($"{DateTime.Now} accept-encodeing = {header}");

            await Next.Invoke(httpcontext);
        }
    }
}
