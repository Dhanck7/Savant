using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Savant.Api.Infrastructure.ActionResults;
using Savant.Api.Infrastructure.Exceptions;

namespace Savant.Api.Infrastructure.Filters
{
    public partial class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

        public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            if (context.Exception is SavantDomainException)
            {
                context.Result = new InternalServerErrorObjectResult(new
                {
                    Messages = new[] { "An error occurred. Try again." },
                    DeveloperMessage = context.Exception
                });
            }
            else
            {
                context.Result = new InternalServerErrorObjectResult(new
                {
                    Messages = new[] { "An error occurred. Try again." }
                });
            }

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.ExceptionHandled = true;
        }
    }
}
