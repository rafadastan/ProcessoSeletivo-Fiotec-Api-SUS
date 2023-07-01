using Api.SUS.Domain.Entities;

namespace Api.SUS.Domain.Contracts.ReadRepo
{
    public interface ISolicitanteReadRepository : IBaseReadRepository<Solicitante, Guid>
    {
        Task<bool> GetByCpfExists(string cpf);
        Task<Solicitante> GetByCpf(string cpf);
    }
}
