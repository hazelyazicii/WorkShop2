using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            await handleExceptionAsync(httpContext, exception);
        }
    }

    private Task handleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = MediaTypeNames.Application.Json;

       
        if (exception is BusinessException businessException)
            return createBusinessProblemDetailsResponse(httpContext, businessException);

        return createInternalProblemDetailsResponse(httpContext, exception);
    }

    private Task createBusinessProblemDetailsResponse(
        HttpContext httpContext,
        BusinessException exception
    )
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        BusinessProblemDetails businessProblemDetails =
            new()
            {
                Title = "Business Exception",
                Type = "https://doc.rentacar.com/business",
                Status = StatusCodes.Status400BadRequest,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

        return httpContext.Response.WriteAsync(businessProblemDetails.ToString());
    }

    private Task createInternalProblemDetailsResponse(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        ProblemDetails problemDetails =
            new()
            {
                Title = "Internal Server Error",
                Type = "https://doc.rentacar.com/internal",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

        return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
    }
}
