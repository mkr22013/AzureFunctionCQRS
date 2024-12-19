using CleanArchitectrure.Application.UseCases.Commons.Bases;
using CleanArchitectrure.Application.UseCases.Commons.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CleanArchitectrure.Application.UseCases.Commons.Behaviours
{
    /// <summary>
    /// This class is used to validate the request before it is processed by the handler.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="validators"></param>
    /// <param name="logger"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public class ValidationBehaviour<TRequest, TResponse>(ILogger<LoggingBehaviour<TRequest, TResponse>> logger,IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Pipeline - Handle method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ValidationExceptionCustom"></exception>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                
                var failures = validationResults
                    .Where(r => r.Errors.Count != 0)
                    .SelectMany(r => r.Errors)
                    .Select(r => new BaseError() { PropertyMessage = r.PropertyName, ErrorMessage = r.ErrorMessage })
                    .ToList();

                if (failures.Count != 0)
                {                   
                    var errors = failures.Select((error) => error.ErrorMessage?.Replace("'" ,""));
                    _logger.LogError(JsonSerializer.Serialize(errors));

                    throw new ValidationExceptionCustom(failures);
                }
            }

            return await next();
        }
    }
}
