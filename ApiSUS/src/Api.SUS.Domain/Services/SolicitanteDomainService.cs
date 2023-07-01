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
            
            if (!CpfValidation.IsValid(entity.CPF))
            {
                _notification.AddNotification(entity.SolicitanteId.ToString(), $"{entity.CPF} é invalido.");
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
                        return;
                    }

                    await _unitOfWork.SaveAsync();
                }
            }
            else
            {
                solicitanteEntity = await _solicitanteReadRepo.GetByCpf(entity.CPF);
            }
            
            var requestListAsync = await _clientService.GetInformationAsync();

            if (requestListAsync == null!)
            {
                _notification.AddNotification(Guid.NewGuid().ToString(), $"Erro ao integrar a api do sus.");
                return;
            }


            var requestFilterList
                = requestListAsync?.Hits.Hits.Where(c => c.Source.VacinacaFabricanteNome == "PFIZER"
                                                           && c.Source.EstabelecimentoUf == "RJ");

            var totalVacina = requestListAsync!.Hits.TotalRequestModel.Value;

            if (requestFilterList != null)
            {
                var responseSusModels = requestFilterList.ToList();
                foreach (var request in responseSusModels)
                {
                    var relatorio = new Relatorio
                    {
                        RelatorioId = Guid.NewGuid(),
                        SolicitanteId = solicitanteEntity!.SolicitanteId,
                        DataSolicitacao = solicitanteEntity.DataConsulta,
                        Descricao = $"Relatório Vacinas Pfizer aplicadas no RJ_{request?.Source.DataAplicacao:d}",
                        DataAplicacao = request!.Source.DataAplicacao,
                        TotalVacinados = responseSusModels.Count()
                    };

                    await CreateRelatorioAsync(relatorio);
                    if (_notification.HasNotifications) return;
                }
            }
        }

        public async Task<int> GetTotalVacinasAplicadas(DateTime date)
        {
            var requestListAsync = await _clientService.GetInformationAsync();

            if (requestListAsync == null!)
            {
                _notification.AddNotification(Guid.NewGuid().ToString(), $"Erro ao integrar a api do sus.");
                return 0;
            }

            var requestFilterList
                = requestListAsync?.Hits.Hits.Where(c => c.Source.VacinacaFabricanteNome == "PFIZER"
                                                         && c.Source.EstabelecimentoUf == "RJ" 
                                                         && c.Source.DataAplicacao == date);

            if (requestFilterList == null)
            {
                _notification.AddNotification(Guid.NewGuid().ToString(), $"Nenhum registro encontrado.");
                return 0;
            }

            return requestFilterList.Count();
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
