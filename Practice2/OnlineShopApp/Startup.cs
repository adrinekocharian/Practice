using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OnlineShopDbContext>(
                optionsBuilder => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));
            services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IProductRepository, ProductMockRepository>();
            services.TryAddScoped<IProductRepository, ProductMockRepository>();
            //services.Replace(new ServiceDescriptor(typeof(IProductRepository), typeof(ProductMockRepository), ServiceLifetime.Scoped));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseCustomMiddleWare();

            app.Use(async (httpcontext, next) =>
            {
                var header = httpcontext.Request.Headers["Accept-Encoding"];
                Console.WriteLine(header);
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute(
                //    name: "product",
                //    pattern: "{controller=Product}/{action=AllProducts}/{id?}");
            });
        }
    }
}
