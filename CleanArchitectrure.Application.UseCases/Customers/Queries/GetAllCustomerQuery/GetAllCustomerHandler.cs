using AutoMapper;
using CleanArchitectrure.Application.Dto;
using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Application.UseCases.Commons.Bases;
using CleanArchitectrure.Application.UseCases.Commons.Util;
using MediatR;

namespace CleanArchitectrure.Application.UseCases.Customers.Queries.GetAllCustomerQuery
{
    /// <summary>
    /// GetAllCustomerHandler
    /// </summary>
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, BaseResponse<IEnumerable<CustomerDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// GetAllCustomerHandler constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetAllCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<BaseResponse<IEnumerable<CustomerDto>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<CustomerDto>>();

            try
            {
                var customers = await _unitOfWork.QCustomers.GetAllAsync();
               
                if(customers is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                    response.Succcess = true;
                    response.Message = "Query succeed!";
                }
            }
            catch (Exception ex)
            {
                Util<IEnumerable<CustomerDto>>.GenerateError(response, ex);
            }

            return response;
        }
    }
}
