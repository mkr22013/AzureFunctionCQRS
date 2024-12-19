using CleanArchitectrure.Domain.Entities;

namespace CleanArchitectrure.Application.Interface.Persistence
{
    /// <summary>
    /// Specific repository for Customer entity
    /// </summary>
    public interface ICustomerQueryRepository: IGenericQueryRepository<Customer>
    {
        /// <summary>
        /// Count the number of customers
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync(); 
    }
}
