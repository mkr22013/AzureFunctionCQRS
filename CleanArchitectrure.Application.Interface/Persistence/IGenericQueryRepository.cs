namespace CleanArchitectrure.Application.Interface.Persistence
{
    /// <summary>
    /// Generic repository for CRUD operation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericQueryRepository<T> where T : class
    {
        /* Queries */
        /// <summary>
        /// Get an entity by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetAsync(string id);
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Get all entities with pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<T>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    }
}
