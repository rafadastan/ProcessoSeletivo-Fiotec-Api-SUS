using Api.SUS.Domain.Entities;

namespace Api.SUS.Domain.Contracts.Repo
{
    public interface ISolicitanteRepository : IBaseRepository<Solicitante, Guid>
    {
        Task<Solicitante> CreateNewSolicitante(Solicitante solicitante);
    }
}
