using CleanArchitectrure.Application.UseCases.Commons.Exceptions;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionCQRS.Extensions.Middleware
{
    /// <summary>
    /// Middleware to handle Authentication exceptions
    /// </summary>
    public class AuthMiddleware() : IFunctionsWorkerMiddleware
    {      
        /// <summary>
        /// Invoke method
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var log = context.GetLogger<ValidationMiddleware>();
            try
            {
                //TODO: All authentication code goes here 
                log.LogInformation("Authentication successfully completed...");

                //Post successful authentication invoke next middleware in pipeline
                await next.Invoke(context);
            }
            catch (ValidationExceptionCustom ex)
            {
              
                var req = await context.GetHttpRequestDataAsync();
                if (req != null)
                {
                    var res = req!.CreateResponse();
                    if (res != null)
                    {
                        await (_ = res.WriteStringAsync(ex.InnerException!.Message));
                        context.InvokeResult(res);
                    }
                }
                else
                {                    
                    log.LogError($"Exception From Middleware : {ex.Message}");
                }
            }
        }
    }
}
