namespace Api.SUS.Domain.Contracts.ReadRepo
{
    public interface IBaseReadRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
    }
}
