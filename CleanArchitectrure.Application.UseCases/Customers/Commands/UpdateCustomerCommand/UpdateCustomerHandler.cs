using AutoMapper;
using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Application.UseCases.Commons.Bases;
using CleanArchitectrure.Domain.Entities;
using MediatR;

namespace CleanArchitectrure.Application.UseCases.Customers.Commands.UpdateCustomerCommand
{
    /// <summary>
    /// UpdateCustomerHandler
    /// </summary>
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// UpdateCustomerHandler constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(command);
                response.Data = await _unitOfWork.CCustomers.UpdateAsync(customer);
                if (response.Data)
                {
                    response.Succcess = true;
                    response.Message = "Update succeed!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
