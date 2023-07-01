using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Application.Contracts;
using Api.SUS.Application.Dto;
using Api.SUS.Application.Model;
using Api.SUS.Domain.Contracts.Domain;
using Api.SUS.Domain.Contracts.ReadRepo;
using Api.SUS.Domain.Entities;
using Api.SUS.Domain.Entities.Base;
using Api.SUS.Domain.Notifications;
using Api.SUS.Reports.Reports;
using AutoMapper;
using DevExpress.XtraReports.UI;

namespace Api.SUS.Application.Services
{
    public class SolicitanteAppService :  ISolicitanteAppService
    {
        private readonly ISolicitanteDomainService _domainService;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notification;
        private readonly ISolicitanteReadRepository _solicitanteReadRepository;
        private readonly IRelatorioReadRepository _relatorioReadRepository;

        public SolicitanteAppService(
            ISolicitanteDomainService domainService, 
            IMapper mapper, 
            NotificationContext notification, 
            ISolicitanteReadRepository solicitanteReadRepository, 
            IRelatorioReadRepository relatorioReadRepository)
        {
            _domainService = domainService;
            _mapper = mapper;
            _notification = notification;
            _solicitanteReadRepository = solicitanteReadRepository;
            _relatorioReadRepository = relatorioReadRepository;
        }

        public async Task<XtraReport> SendAsync(SolicitanteModel model)
        {
            RemoveSpecialCharacterCpf(model);

            var solicitanteDto = SolicitanteFactory(model);

            var solicitante = _mapper.Map<Solicitante>(solicitanteDto);

            await _domainService.CreateSolicitanteAsync(solicitante);
            if (_notification.HasNotifications) return null;
            
            var dadosSolicitante = await _solicitanteReadRepository.GetByCpf(model.CPF);
            if (dadosSolicitante == null)
            {
                _notification.AddNotification(Guid.NewGuid().ToString(), "Erro ao buscar dado no banco de dados.");
                return null;
            }

            var dadosRelatorio =
                await _relatorioReadRepository.GetAllBySolicitanteAsync(dadosSolicitante.SolicitanteId);
            
            return !_notification.HasNotifications ? new RelatorioSus(dadosRelatorio) : null!;
        }
        
        public async Task<int> GetTotalVacinasAplicada(DateTime date)
        {
            var total = await _domainService.GetTotalVacinasAplicadas(date);
            if (_notification.HasNotifications) return 0;

            return total;
        }

        private SolicitanteDto SolicitanteFactory(SolicitanteModel model)
        {
            return new SolicitanteDto
            {
                Nome = model.Nome,
                CPF = model.CPF,
                DataConsulta = DateTime.Now.Date
            };
        }

        private static void RemoveSpecialCharacterCpf(SolicitanteModel model)
        {
            model.CPF = String.Join("", System.Text.RegularExpressions.Regex.Split(model.CPF, @"[^\d]"));
        }
    }
}
