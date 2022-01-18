using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AptekaWebAPI.Middleware;
using AptekaWebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace AptekaWebAPI
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
            services.AddControllers();
            services.AddScoped<ErrorHandlerMiddleware>();
            services.AddScoped<AuthentificationMiddleware>();
            services.AddScoped<AccessStatusMiddleware>();
            services.AddDbContext<PharmacyContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //app.UseMiddleware<ErrorHandlerMiddleware>();
            //app.UseMiddleware<AuthentificationMiddleware>();
            //app.UseMiddleware<AccessStatusMiddleware>();
            app.UseAuthentication();

            app.Run(async (cont) =>
            {
                await cont.Response.WriteAsync("Hello");
            });
        }
    }
}
