using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Domain.Entities;
//using CleanArchitectrure.Persistence.Contexts;

namespace CleanArchitectrure.Persistence.Repositories
{
    /// <summary>
    /// Customer Query Repository
    /// </summary>
    public class CustomerQueryRepository : ICustomerQueryRepository
    {             
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationContext"></param>
        public CustomerQueryRepository() //DapperContext applicationContext - Inject the DapperContext once we want to read things from DB
        {
          
        }

        #region Queries
        /*Queries*/
        /// <summary>
        /// Count the number of customers
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountAsync()
        {          
           return await Task.Run(() => Util.CustomersList.Count);            
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
           return await Task.Run(() => Util.CustomersList);
        }

        /// <summary>
        /// Get all customers with pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await Task.Run(() => Util.CustomersList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Get selected customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer?> GetAsync(string id)
        {
            if (Util.CustomersList.Count == 0)
                return null;

            Customer customer = new();
            foreach (var cust in Util.CustomersList)
            {
                if (cust.CustomerId == id)
                {
                    customer = cust;
                    break;
                }
            }

            return await Task.Run(() => customer);
        }
        #endregion
    }
}
