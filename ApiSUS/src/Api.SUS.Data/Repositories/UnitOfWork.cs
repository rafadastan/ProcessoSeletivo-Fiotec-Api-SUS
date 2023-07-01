using Api.SUS.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using Api.SUS.Domain.Contracts.Repo;

namespace Api.SUS.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _sqlContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(SqlContext sqlContext, 
            IDbContextTransaction transaction)
        {
            _sqlContext = sqlContext;
            _transaction = transaction;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _sqlContext
                .Database
                .BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }

        public async Task SaveAsync()
        {
            await _sqlContext.SaveChangesAsync();
        }

        public IRelatorioRepository RelatorioRepository => new RelatorioRepository(_sqlContext);
        public ISolicitanteRepository SolicitanteRepository => new SolicitanteRepository(_sqlContext);
    }
}
