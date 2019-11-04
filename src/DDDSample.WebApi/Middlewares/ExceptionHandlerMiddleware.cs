using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Infrastructure.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DDDSample.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            IHostingEnvironment hostingEnvironment = httpContext.RequestServices.GetRequiredService<IHostingEnvironment>();

            Result response = Result.Fail(0, "系统异常，请稍候再试。");

            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                if (httpContext.Response.HasStarted)
                {
                    throw;
                }

                if (httpContext.Request.Query.ContainsKey("throw"))
                {
                    throw;
                }

                if (!hostingEnvironment.IsProduction() || httpContext.Request.Query.ContainsKey("debug")
                                                       || httpContext.Request.Query.ContainsKey("Debug")
                                                       || httpContext.Request.Query.ContainsKey("stacktrace")
                                                       || httpContext.Request.Query.ContainsKey("stackTrace")
                                                       || httpContext.Request.Query.ContainsKey("StackTrace"))
                {
                    response.Data = e.Message + "\r\n" + e.StackTrace;
                }

                httpContext.Response.ContentType = "application/json; charset=utf-8";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
