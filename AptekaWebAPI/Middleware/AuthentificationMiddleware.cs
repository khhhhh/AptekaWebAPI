using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Middleware
{
    public class AuthentificationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                var token = context.Request.Query["Auth"].ToString().Split("/").FirstOrDefault(); //add regex to split
                if(string.IsNullOrWhiteSpace(token))
                {
                    throw new Exception();
                }

                await context.Response.WriteAsync($"authorized : {token}");
               // await next.Invoke(context);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Not authorized");
            }

        }
    }
}
