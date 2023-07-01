using Api.SUS.Domain.Entities;
using Api.SUS.Domain.Model.QueryModel;

namespace Api.SUS.Domain.Contracts.ReadRepo
{
    public interface IRelatorioReadRepository : IBaseReadRepository<Relatorio, Guid>
    {
        Task<Relatorio> GetByIdAsync(Guid id);
        Task<IEnumerable<RelatorioBySolicitanteDto>> GetAllBySolicitanteAsync(Guid solicitanteId);
    }
}
