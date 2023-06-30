using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Api.SUS.Application.Dto;
using Api.SUS.Domain.Entities;

namespace Api.SUS.Application.Profiles
{
    public class RelatorioProfile : Profile
    {
        public RelatorioProfile()
        {
            CreateMap<Relatorio, RelatorioDto>()
                .AfterMap((src, dest) =>
                {
                    src.RelatorioId = Guid.NewGuid();
                }).ReverseMap();
        }
    }
}
