using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CleanArchitectrure.Application.UseCases.Commons.Behaviours
{
    /// <summary>
    /// LoggingBehaviour
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="logger"></param>
    public class LoggingBehaviour<TRequest, TResponse>(ILogger<LoggingBehaviour<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Clean Architecture Request Handling: { name } {@request }", typeof(TRequest).Name, JsonSerializer.Serialize(request));
            var response = await next();
            _logger.LogInformation("Clean Architecture Response Handling: { name } {@response }", typeof(TResponse).Name, JsonSerializer.Serialize(response));

            return response;
        }
    }
}
