namespace AndreBrandaoCloudGamesApi.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task DeleteEntityAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> Exists(Guid id);

    }
}

