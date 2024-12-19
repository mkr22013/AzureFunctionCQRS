using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;

namespace AzureFunctionCQRS.Extensions.Middleware
{
    /// <summary>
    /// Middleware Extension
    /// </summary>
    public static class MiddlewareExtension
    {
        /// <summary>
        /// Add Middleware
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IFunctionsWorkerApplicationBuilder AddMiddleware(this IFunctionsWorkerApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidationMiddleware>();
        }
    }
}
