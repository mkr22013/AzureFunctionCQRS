using AutoMapper;
using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Application.UseCases.Commons.Bases;
using CleanArchitectrure.Domain.Entities;
using MediatR;

namespace CleanArchitectrure.Application.UseCases.Customers.Commands.CreateCustomerCommand
{
    /// <summary>
    /// CreateCustomerHandler
    /// </summary>
    /// <remarks>
    /// CreateCustomerHandler
    /// </remarks>
    /// <param name="unitOfWork"></param>
    /// <param name="mapper"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public class CreateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateCustomerCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(command);
                response.Data = await _unitOfWork.CCustomers.InsertAsync(customer);
                if (response.Data) 
                {
                    response.Succcess = true;
                    response.Message  = "Create succeed!";
                }
            }
            catch (Exception ex)
            {
                response.Message  = ex.Message;
            }
            return response;
        }
    }
}
