namespace CleanArchitectrure.Application.Interface.Persistence
{
    /// <summary>
    /// Generic repository for CRUD operation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericCommandRepository<T> where T : class
    {
        /* Commands */
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);       
    }
}
