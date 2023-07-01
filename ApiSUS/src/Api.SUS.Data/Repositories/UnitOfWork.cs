using Api.SUS.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using Api.SUS.Domain.Contracts.Repo;

namespace Api.SUS.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _sqlContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _sqlContext
                .Database
                .BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _sqlContext
                .Database.CommitTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            await _sqlContext.Database.RollbackTransactionAsync();
        }

        public async Task SaveAsync()
        {
            await _sqlContext.SaveChangesAsync();
        }

        public IRelatorioRepository RelatorioRepository => new RelatorioRepository(_sqlContext);
        public ISolicitanteRepository SolicitanteRepository => new SolicitanteRepository(_sqlContext);
    }
}
