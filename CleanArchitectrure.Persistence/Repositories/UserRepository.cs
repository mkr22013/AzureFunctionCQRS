using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Domain.Entities;
using CleanArchitectrure.Persistence.Contexts;
using Dapper;
using System.Data;

namespace CleanArchitectrure.Persistence.Repositories
{
    /// <summary>
    /// User Repository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _applicationContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationContext"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserRepository(DapperContext applicationContext)
        {
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        /// <summary>
        /// Get user by client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public Task<User> GetAync(string client)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "UsersGetByClient";

            var parameters = new DynamicParameters();
            parameters.Add("Client", client);

            var user = connection.QuerySingleOrDefaultAsync<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return user;
        }

        /// <summary>
        /// Insert a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> InsertAync(User user)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "UsersInsert";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", user.UserId);
            parameters.Add("Company", user.Company);
            parameters.Add("Abbreviation", user.Abbreviation);
            parameters.Add("Client", user.Client);
            parameters.Add("Secret", user.Secret);

            var recordsAffected = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            return recordsAffected > 0;
        }
    }
}
