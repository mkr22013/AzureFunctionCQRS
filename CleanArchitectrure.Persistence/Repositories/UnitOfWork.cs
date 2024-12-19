using CleanArchitectrure.Application.Interface.Persistence;

namespace CleanArchitectrure.Persistence.Repositories
{
    /// <summary>
    /// Unit of work for repositories
    /// </summary>
    internal class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// User repository
        /// </summary>
        public IUserRepository Users { get; }

        /// <summary>
        /// Customer query repository
        /// </summary>
        public ICustomerQueryRepository QCustomers { get; }

        /// <summary>
        /// Customer command repository
        /// </summary>
        public ICustomerCommandRepository CCustomers { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="users"></param>
        /// <param name="qCustomers"></param>
        /// <param name="cCustomers"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UnitOfWork(IUserRepository users, ICustomerQueryRepository qCustomers, ICustomerCommandRepository cCustomers)
        {
            Users = users ?? throw new ArgumentNullException(nameof(users));
            QCustomers = qCustomers ?? throw new ArgumentNullException(nameof(qCustomers));
            CCustomers = cCustomers ?? throw new ArgumentNullException(nameof(cCustomers));
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
