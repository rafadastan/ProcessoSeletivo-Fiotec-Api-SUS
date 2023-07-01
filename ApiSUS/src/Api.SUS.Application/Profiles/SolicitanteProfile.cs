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
            CreateMap<SolicitanteDto, Solicitante>()
                .ForMember(
                    dest => dest.SolicitanteId,
                    opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Nome))
                .ForMember(
                    dest => dest.CPF,
                    opt => opt.MapFrom(src => src.CPF))
                .ForMember(
                    dest => dest.DataConsulta,
                    opt => opt.MapFrom(src => src.DataConsulta))
                .ReverseMap();
        }
    }
}
