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
            //Middleware will be executed in the same order as it is mentioned below
            builder.UseMiddleware<AuthMiddleware>();
            builder.UseMiddleware<ValidationMiddleware>();
            return builder;
        }
    }
}
