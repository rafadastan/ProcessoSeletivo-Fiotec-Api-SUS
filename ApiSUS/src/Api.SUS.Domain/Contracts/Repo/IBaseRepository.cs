namespace Api.SUS.Domain.Contracts.Repo
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
