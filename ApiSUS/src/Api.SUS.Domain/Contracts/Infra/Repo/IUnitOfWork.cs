using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Domain.Contracts.Infra.Repo
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
