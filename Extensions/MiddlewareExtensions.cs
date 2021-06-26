using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using my_books.Data.Models;

namespace my_books.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(exception =>
            {
                exception.Run((async context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var possibleError = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();

                    if (possibleError != null)
                    {
                        var error = new ErrorModel()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = possibleError.Error.Message,
                            Path = contextRequest.Path
                        };
                        
                        await context.Response.WriteAsync(error.ToString());
                    }
                }));
            });
        }
    }
}
