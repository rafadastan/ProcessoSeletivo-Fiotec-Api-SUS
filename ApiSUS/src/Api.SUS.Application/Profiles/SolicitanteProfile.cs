using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Application.Dto;
using Api.SUS.Domain.Entities;

namespace Api.SUS.Application.Profiles
{
    public class SolicitanteProfile : Profile
    {
        public SolicitanteProfile()
        {
            CreateMap<Solicitante, SolicitanteDto>()
                .AfterMap((src, dest) =>
                {
                    src.SolicitanteId = Guid.NewGuid();
                }).ReverseMap();
        }
    }
}
