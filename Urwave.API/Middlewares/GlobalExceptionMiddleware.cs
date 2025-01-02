using Serilog;
using System.Net;
using Urwave.Application.Exceptions;
using Urwave.Application.Resources;

namespace Urwave.API.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        ApiResponse response;

        if (exception is NotFoundException)
        {
            response = new ApiResponse
            {
                IsSuccess = false,
                Message = exception.Message,
            };
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }

        else
        {
            Log.Error(exception, "An unhandled exception occurred while processing the request.");
            response = new ApiResponse
            {
                IsSuccess = false,
                Message = "Something Went Wrong!",
            };
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        context.Response.ContentType = "application/json";

        return context.Response.WriteAsJsonAsync(response);
    }
}
