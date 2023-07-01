using Api.SUS.Domain.Model.IntegrationModel;

namespace Api.SUS.Domain.Contracts.Client
{
    public interface ISusClientService
    {
        Task<MainRequestDto> GetInformationAsync();
    }
}
