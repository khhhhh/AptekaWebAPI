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
using AutoMapper;
using AptekaWebAPI.Services;
using AptekaWebAPI.Services.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AptekaWebAPI.Tokens;
using Microsoft.OpenApi.Models;
using AptekaWebAPI.Entities;
using AptekaWebAPI.AutoMapping;
using AptekaWebAPI.Services.Interfaces;

namespace AptekaWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PharmacyContext>(options =>
                          options.UseSqlServer(Configuration.GetConnectionString("ConnectionCS")));


            services.AddScoped<PharamcySeeder>();

            var jwtSection = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSection);

            var appSettings = jwtSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddControllers();

            services.AddAutoMapper(GetType().Assembly);
            services.AddScoped<IAutrhenticationService, AuthenticationService>();
            services.AddScoped<IPharmacyUserService, PharmacyUserService>();
            services.AddScoped<IPharmacyAdminService, PharmacyAdminService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IBuyService, BuyService>();

            services.AddSingleton(AutoMapperConfiguration.Initialize());

            //services.AddDbContext<PharmacyContext>(options =>
            //    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<ErrorHandlerMiddleware>();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PharamcySeeder seeder)
        {
            seeder.Seed();

            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AptekatWebApi");
                });

            }

            app.UseMiddleware<ErrorHandlerMiddleware>();


            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
