using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Middleware
{
    public class AccessStatusMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                var token = context.Request.Query["Auth"].ToString().Split("/").FirstOrDefault(); //add regex to split
                if (string.IsNullOrWhiteSpace(token)) // add new cases to check
                {
                    throw new Exception();
                }

                await next.Invoke(context);
                //await context.Response.WriteAsync($"authorized : {token}");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Not authorized");
            }

        }
    }
}
