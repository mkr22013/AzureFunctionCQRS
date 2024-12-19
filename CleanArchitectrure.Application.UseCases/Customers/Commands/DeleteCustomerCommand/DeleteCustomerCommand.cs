using CleanArchitectrure.Application.UseCases.Commons.Bases;
using MediatR;

namespace CleanArchitectrure.Application.UseCases.Customers.Commands.DeleteCustomerCommand
{
    /// <summary>
    /// DeleteCustomerCommand
    /// </summary>
    public class DeleteCustomerCommand: IRequest<BaseResponse<bool>>
    {
        /// <summary>
        /// CustomerId
        /// </summary>
        public string CustomerId { get; set; }
    }
}
