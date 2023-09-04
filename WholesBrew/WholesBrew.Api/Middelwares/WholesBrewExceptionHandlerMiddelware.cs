using Microsoft.EntityFrameworkCore;
using System.Net;
using Helper;

namespace WholesBrew.Api.Middelwares
{
    public class WholesBrewExceptionHandlerMiddelware : AbstractExceptionHandlerMiddelware
    {
        public WholesBrewExceptionHandlerMiddelware(RequestDelegate next, ILogger<WholesBrewExceptionHandlerMiddelware> logger)
            : base(next, logger)
        {
        }

        public override HttpStatusCode GetHttpStatusCode(Exception exception)
        {
            HttpStatusCode statusCode = exception switch
            {
                DbUpdateConcurrencyException
                    => HttpStatusCode.Conflict,
                _
                    => base.GetHttpStatusCode(exception)
            };

            return statusCode;
        }
    }
}
