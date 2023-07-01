﻿using System;
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
            var solicitanteDto = SolicitanteFactory(model);

            var solicitante = _mapper.Map<Solicitante>(solicitanteDto);

            await _domainService.CreateSolicitanteAsync(solicitante);
            if (_notification.HasNotifications) return null;
            
            var dadosSolicitante = await _solicitanteReadRepository.GetByCpfAndName(model.Nome, model.CPF);

            var dadosRelatorio =
                await _relatorioReadRepository.GetAllBySolicitanteAsync(dadosSolicitante.SolicitanteId);
            
            return !_notification.HasNotifications ? new RelatorioSus(dadosRelatorio) : null!;
        }

        private SolicitanteDto SolicitanteFactory(SolicitanteModel model)
        {
            return new SolicitanteDto
            {
                Nome = model.Nome,
                CPF = model.CPF,
                DataConsulta = model.DataSolicitante ?? DateTime.Now.Date
            };
        }
    }
}