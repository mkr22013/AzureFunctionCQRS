using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Domain.Entities;
//using CleanArchitectrure.Persistence.Contexts;

namespace CleanArchitectrure.Persistence.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        /// <summary>
        /// Constructor
        /// Inject any dependency here
        /// </summary>
        /// <param name="applicationContext"></param>
        public CustomerCommandRepository() //DapperContext applicationContext - Inject the DapperContext once we want to read things from DB
        {

        }

        #region Commands
       
        /// <summary>
        /// Creating new customer record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(Customer entity)
        {
            var cust = Util.CustomersList.Aggregate((i1, i2) => Convert.ToInt32(i1.CustomerId) > Convert.ToInt32(i2.CustomerId) ? i1 : i2);
            int newId = 0;
            if (cust == null)
            {
                newId = 1;
            }
            else
            {
                newId = Convert.ToInt32(cust.CustomerId) + 1;
            }

            var customer = new Customer
            {
                CustomerId = Convert.ToString(newId),
                Address = entity.Address,
                City = entity.City,
                Country = entity.Country,
                Phone = entity.Phone,
                Fax = entity.Fax,
                ContactName = entity.ContactName,
                CompanyName = entity.CompanyName,
                ContactTitle = entity.ContactTitle
            };
            customer.Phone = entity.Phone;
            await Task.Run(() => Util.CustomersList.Add(customer));
            Util.Id = Util.Id + 1;
            return true;
        }

        /// <summary>
        /// Updating an existing customer record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Customer entity)
        {
            foreach (var customer in Util.CustomersList)
            {
                if (customer.CustomerId == entity.CustomerId)
                {
                    customer.Address = entity.Address;
                    customer.City = entity.City;
                    customer.Country = entity.Country;
                    customer.Phone = entity.Phone;
                    customer.PostalCode = entity.PostalCode;
                    customer.CompanyName = entity.CompanyName;
                    customer.ContactName = entity.ContactName;
                    customer.ContactTitle = entity.ContactTitle;
                    customer.Fax = entity.Fax;
                }
            }

            return await Task.Run(() => true);
        }

        /// <summary>
        /// Deleting an existing customer record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string id)
        {
            if (Util.CustomersList.Count == 0)
                return false;

            var result = await Task.Run(() => Util.CustomersList.RemoveAll(cust => cust.CustomerId == id));
            return result == 1;
        }

        #endregion
    }
}
