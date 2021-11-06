using ExpertDirectory.API.Models;
using ExpertDirectory.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ExpertDirectory.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        #region Fields
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        #endregion

        #region MyRegion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestDelegate"></param>
        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }
        #endregion

        #region Methods

        public async Task Invoke(HttpContext httpContext) 
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.ToString());
                await ExceptionHandler(httpContext, exception);
            }
        }

        private static Task ExceptionHandler(HttpContext httpContext, Exception exception) 
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var errorMessageObject = new ExceptionResponse 
            { 
                Message = exception.Message,
                ResponseCode = statusCode,
                ResponseDateTime = DateTime.UtcNow
            };            
            switch (exception)
            {
                case NotFoundException:
                    statusCode = (int)HttpStatusCode.BadRequest;                      
                    break;
                case ValidationException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
            }
            errorMessageObject.ResponseCode = statusCode;
            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);           

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            return httpContext.Response.WriteAsync(errorMessage);
        }

        #endregion
    }
}
