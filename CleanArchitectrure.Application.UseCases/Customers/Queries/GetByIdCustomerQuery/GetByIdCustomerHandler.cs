using AutoMapper;
using CleanArchitectrure.Application.Dto;
using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Application.UseCases.Commons.Bases;
using MediatR;

namespace CleanArchitectrure.Application.UseCases.Customers.Queries.GetByIdCustomerQuery
{
    /// <summary>
    /// GetByIdCustomerHandler
    /// </summary>
    public class GetByIdCustomerHandler : IRequestHandler<GetByIdCustomerQuery, BaseResponse<CustomerDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// GetByIdCustomerHandler constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetByIdCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BaseResponse<CustomerDto>> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CustomerDto>();
            try
            {
                var customer = await _unitOfWork.QCustomers.GetAsync(request.CustomerId);
                if(customer is not null)
                {
                    response.Data = _mapper.Map<CustomerDto>(customer);
                    response.Succcess = true;
                    response.Message = "Query succeed!";
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
