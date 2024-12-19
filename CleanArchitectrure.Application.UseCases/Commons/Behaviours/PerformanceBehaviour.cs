using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace CleanArchitectrure.Application.UseCases.Commons.Behaviours
{
    /// <summary>
    /// Performance behaviour pipeline
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <remarks>
    /// PerformanceBehaviour constructor
    /// </remarks>
    /// <param name="logger"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public class PerformanceBehaviour<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer = new Stopwatch() ?? throw new ArgumentNullException(nameof(Stopwatch));
        private readonly ILogger<TRequest> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();
            var response = await next();
            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;
            if (elapsedMilliseconds > 10)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogWarning("Clean Architecture Long Running: {name} ({elapsedMilliseconds} milliseconds) {@request}",
                    requestName,
                    elapsedMilliseconds,
                    JsonSerializer.Serialize(request));
            }
            return response;
        }
    }
}
