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
            CreateMap<RelatorioDto, Relatorio>()
                .ForMember(
                    dest => dest.RelatorioId,
                    opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(
                    dest => dest.DataAplicacao,
                    opt => opt.MapFrom(src => src.DataAplicacao))
                .ForMember(
                    dest => dest.Descricao,
                    opt => opt.MapFrom(src => src.Descricao))
                .ForMember(
                    dest => dest.TotalVacinados,
                    opt => opt.MapFrom(src => src.TotalVacinados))
                .ForMember(
                    dest => dest.DataSolicitacao,
                    opt => opt.MapFrom(src => src.DataSolicitacao))
                .ReverseMap();
        }
    }
}
