using Api.SUS.Client.Dto;
using Api.SUS.Domain.Model.IntegrationModel;

namespace Api.SUS.Domain.Contracts.Client
{
    public interface ISusClientService
    {
        Task<List<MainRequestDto>?> GetInformationAsync();
    }
}
