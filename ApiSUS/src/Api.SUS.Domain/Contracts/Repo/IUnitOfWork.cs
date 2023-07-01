namespace Api.SUS.Domain.Contracts.Repo
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveAsync();

        IRelatorioRepository RelatorioRepository { get; }
        ISolicitanteRepository SolicitanteRepository { get; }
    }
}
