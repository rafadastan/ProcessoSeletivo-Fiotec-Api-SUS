using Api.SUS.Domain.Contracts.ReadRepo;

namespace Api.SUS.Data.ReadRepositories
{
    public abstract class BaseReadRepository<TEntity, TKey> : IBaseReadRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
    }
}
