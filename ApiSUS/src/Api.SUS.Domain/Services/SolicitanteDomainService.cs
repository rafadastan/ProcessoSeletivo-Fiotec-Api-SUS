using Api.SUS.Domain.Contracts.Domain;
using Api.SUS.CrossCutting.Validators.ServiceValidators;
using Api.SUS.Domain.Contracts.Client;
using Api.SUS.Domain.Contracts.ReadRepo;
using Api.SUS.Domain.Contracts.Repo;
using Api.SUS.Domain.Entities;
using Api.SUS.Domain.Notifications;
using Api.SUS.Domain.Model;

namespace Api.SUS.Domain.Services
{
    public class SolicitanteDomainService : ISolicitanteDomainService
    {
        private readonly NotificationContext _notification;
        private readonly ISolicitanteReadRepository _solicitanteReadRepo;
        private readonly ISolicitanteRepository _solicitanteRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISusClientService _clientService;
        private readonly IRelatorioRepository _relatorioRepository;

        public SolicitanteDomainService(
            NotificationContext notification, 
            ISolicitanteReadRepository solicitanteReadRepo,
            ISolicitanteRepository solicitanteRepo, IUnitOfWork unitOfWork, 
            ISusClientService clientService, 
            IRelatorioRepository relatorioRepository)
        {
            _notification = notification;
            _solicitanteReadRepo = solicitanteReadRepo;
            _solicitanteRepo = solicitanteRepo;
            _unitOfWork = unitOfWork;
            _clientService = clientService;
            _relatorioRepository = relatorioRepository;
        }

        public async Task CreateSolicitanteAsync(Solicitante entity)
        { 
            Solicitante solicitanteEntity;

            if (CpfValidation.IsValid(entity.CPF))
            {
                _notification.AddNotification(entity.Id.ToString(), $"{entity.CPF} é invalido.");
                return;
            }

            var hasSolicitante = await _solicitanteReadRepo.GetByCpfExists(entity.CPF);

            if (!hasSolicitante)
            {
                using (_unitOfWork.BeginTransactionAsync())
                {
                    solicitanteEntity = await _solicitanteRepo.CreateNewSolicitante(entity);
                    
                    if (solicitanteEntity == null!)
                    {
                        _notification.AddNotification(Guid.NewGuid().ToString(), $"Erro ao salvar.");
                    }

                    await _unitOfWork.SaveAsync();
                }
            }
            else
            {
                solicitanteEntity = await _solicitanteReadRepo.GetByCpfAndName(entity.CPF, entity.Nome);
            }
            
            var requestListAsync = await _clientService.GetInformationAsync();

            if (requestListAsync == null)
                _notification.AddNotification(Guid.NewGuid().ToString(), $"Erro ao integrar a api do sus.");


            var requestFilterList 
                = requestListAsync?.Where(r => r.Hits.Hits.Source.VacinacaFabricanteNome == "PFIZER" 
                                              && r.Hits.Hits.Source.EstabelecimentoUf == "RJ");

            foreach (var request in requestFilterList)
            {
                var relatorio = new Relatorio(Guid.NewGuid())
                {
                    SolicitanteId = solicitanteEntity!.SolicitanteId,
                    DataSolicitacao = solicitanteEntity.DataConsulta,
                    Descricao = $"Relatório Vacinas Pfizer aplicadas no RJ_{request?.Hits?.Hits?.Source?.DataAplicacao}",
                    DataAplicacao = request.Hits.Hits.Source.DataAplicacao,
                    TotalVacinados = request.Shareds.Total
                };

                await CreateRelatorioAsync(relatorio);
                if (_notification.HasNotifications) return null;
            }

            return requestFilterList;
        }

        private async Task CreateRelatorioAsync(Relatorio relatorio)
        {
            using (_unitOfWork.BeginTransactionAsync())
            {
                await _relatorioRepository.CreateAsync(relatorio);
                if (_notification.HasNotifications) return;

                await _unitOfWork.SaveAsync();
            }
        }
    }
}
