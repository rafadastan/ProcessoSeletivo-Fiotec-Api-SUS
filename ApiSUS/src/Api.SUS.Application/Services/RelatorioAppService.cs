using Api.SUS.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Application.Dto;
using Api.SUS.Domain.Contracts.ReadRepo;
using Api.SUS.Domain.Notifications;
using AutoMapper;
using Api.SUS.Domain.Entities;

namespace Api.SUS.Application.Services
{
    public class RelatorioAppService : IRelatorioAppService
    {
        private readonly IRelatorioReadRepository _repository;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notification;

        public RelatorioAppService(
            IRelatorioReadRepository repository, 
            IMapper mapper, 
            NotificationContext notification)
        {
            _repository = repository;
            _mapper = mapper;
            _notification = notification;
        }

        public async Task<IEnumerable<RelatorioDto>> GetAll()
        {
            var relatorioListAll = await _repository.GetAllAsync();
            if (relatorioListAll == null!)
            {
                _notification.AddNotification(Guid.NewGuid().ToString(), $"Erro ao buscar dados de Relatorio.");
                return null;
            }

            return _mapper.Map<IEnumerable<RelatorioDto>>(relatorioListAll);
        }
    }
}
