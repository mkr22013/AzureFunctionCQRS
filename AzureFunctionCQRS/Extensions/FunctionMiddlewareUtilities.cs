using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionCQRS.Extensions
{
    /// <summary>
    /// Utility Function for Middleware
    /// </summary>
    internal static class FunctionMiddlewareUtilities
    {
        /// <summary>
        /// Read the request data from context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        internal static HttpRequestData? GetHttpRequestData(this FunctionContext context)
        {
            var keyValuePair = context.Features.SingleOrDefault(f => f.Key.Name == "IFunctionBindingsFeature");
            var functionBindingsFeature = keyValuePair.Value;
            var type = functionBindingsFeature.GetType();
            var inputData = type.GetProperties().Single(p => p.Name == "InputData").GetValue(functionBindingsFeature) as IReadOnlyDictionary<string, object>;
            return inputData?.Values.SingleOrDefault(o => o is HttpRequestData) as HttpRequestData;
        }

        /// <summary>
        /// Send the result 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="response"></param>
        internal static void InvokeResult(this FunctionContext context, HttpResponseData response)
        {
            var keyValuePair = context.Features.SingleOrDefault(f => f.Key.Name == "IFunctionBindingsFeature");
            var functionBindingsFeature = keyValuePair.Value;
            var type = functionBindingsFeature.GetType();
            var result = type.GetProperties().Single(p => p.Name == "InvocationResult");
            result.SetValue(functionBindingsFeature, response);
        }
    }
}
