using CleanArchitectrure.Application.UseCases.Commons.Exceptions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MediatR;
using CleanArchitectrure.Application.UseCases.Customers.Queries.GetAllCustomerQuery;
using CleanArchitectrure.Application.Dto;

namespace AzureFunctionCQRS
{
    public class GetAllCustomerFunction(ILoggerFactory loggerFactory, IMediator mediator)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<GetAllCustomerFunction>();
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [Function("GetAllCustomer")]
        public async Task<IEnumerable<CustomerDto>?> RunAsync([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {myTimer.ScheduleStatus?.Last}");
            
            //TODO : Call actual stuff
            var response = await _mediator.Send(new GetAllCustomerQuery());
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
            if (response.Succcess)
            {
                return response.Data;
            }
            else
            {
               throw new ValidationExceptionCustom(response.Errors);
            }           
        }
    }
}
