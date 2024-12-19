using CleanArchitectrure.Domain.Entities;

namespace CleanArchitectrure.Application.Interface.Persistence
{
    /// <summary>
    /// Customer command repository
    /// </summary>
    public interface ICustomerCommandRepository: IGenericCommandRepository<Customer>
    {
        //TODO : Add specific command methods those are not covered by the generic repository
    }
}
