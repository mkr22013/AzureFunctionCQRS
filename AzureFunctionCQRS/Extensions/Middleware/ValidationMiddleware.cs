using CleanArchitectrure.Application.UseCases.Commons.Exceptions;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionCQRS.Extensions.Middleware
{

    /// <summary>
    /// Middleware to handle validation exceptions
    /// </summary>
    public class ValidationMiddleware() : IFunctionsWorkerMiddleware
    {      
        /// <summary>
        /// Invoke method
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (ValidationExceptionCustom ex)
            {
              
                var req = await context.GetHttpRequestDataAsync();
                if (req != null)
                {
                    var res = req!.CreateResponse();
                    res?.WriteStringAsync(ex.InnerException.Message);
                    context.InvokeResult(res);
                }
                else
                {
                    var log = context.GetLogger<ValidationMiddleware>();
                    log.LogError($"Exception From Middleware : {ex.Message}");
                }
            }
        }
    }
}
