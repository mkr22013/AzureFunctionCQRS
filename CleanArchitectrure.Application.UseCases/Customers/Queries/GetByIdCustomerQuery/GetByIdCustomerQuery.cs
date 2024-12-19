using CleanArchitectrure.Application.Dto;
using CleanArchitectrure.Application.UseCases.Commons.Bases;
using MediatR;

namespace CleanArchitectrure.Application.UseCases.Customers.Queries.GetByIdCustomerQuery
{
    /// <summary>
    /// GetByIdCustomerQuery
    /// </summary>
    public class GetByIdCustomerQuery: IRequest<BaseResponse<CustomerDto>>
    {
        /// <summary>
        /// CustomerId
        /// </summary>
        public string? CustomerId { get; set; }
    }
}
