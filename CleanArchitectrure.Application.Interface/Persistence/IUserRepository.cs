using CleanArchitectrure.Domain.Entities;

namespace CleanArchitectrure.Application.Interface.Persistence
{
    /// <summary>
    /// Specific repository for User entity
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get a user by its client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task<User> GetAync(string client);

        /// <summary>
        /// Insert a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> InsertAync(User user);
    }
}
