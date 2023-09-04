using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Helper
{
    public abstract class AbstractExceptionHandlerMiddelware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<AbstractExceptionHandlerMiddelware> _logger;

        protected AbstractExceptionHandlerMiddelware(RequestDelegate next, ILogger<AbstractExceptionHandlerMiddelware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public virtual HttpStatusCode GetHttpStatusCode(Exception exception)
        {
            if (1 == 0)
            {
            }

            HttpStatusCode result = !(exception is EntityNotFoundException) ? HttpStatusCode.InternalServerError : HttpStatusCode.NotFound;
            if (1 == 0)
            {
            }

            return result;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                if (exception is AggregateException)
                {
                    exception = exception.InnerException;
                }

                ILogger<AbstractExceptionHandlerMiddelware> logger = _logger;
                Exception exception2 = exception;
                string errorMessage = $"An error occurred during the execution of {context.Request.Path}";
                logger.LogError(exception2, errorMessage);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)GetHttpStatusCode(exception);

                await context.Response.WriteAsync(JsonConvert.SerializeObject(exception));
            }
        }
    }

}
