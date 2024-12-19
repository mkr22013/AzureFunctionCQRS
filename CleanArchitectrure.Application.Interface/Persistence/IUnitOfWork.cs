namespace CleanArchitectrure.Application.Interface.Persistence
{
    /// <summary>
    /// Unit of work for repositories
    /// </summary>
    public interface IUnitOfWork: IDisposable
    {
        /// <summary>
        /// User repository
        /// </summary>
        IUserRepository Users { get; }
        /// <summary>
        /// Customer repository
        /// </summary>
        ICustomerQueryRepository QCustomers { get; }
        /// <summary>
        /// Customer command repository
        /// </summary>
        ICustomerCommandRepository CCustomers { get; }
    }
}
