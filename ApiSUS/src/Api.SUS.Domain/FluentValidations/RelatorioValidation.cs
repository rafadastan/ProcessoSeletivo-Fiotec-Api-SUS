using Api.SUS.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Domain.FluentValidations
{
    public class RelatorioValidation : AbstractValidator<Relatorio>
    {
        public RelatorioValidation()
        {
            RuleFor(r => r.RelatorioId)
                .NotEmpty()
                .WithMessage("O Id não pode ser nulo.");

            RuleFor(r => r.DataAplicacao)
                .NotEmpty()
                .WithMessage("DataAplicacao não pode ser nulo.");

            RuleFor(r => r.DataSolicitacao)
                .NotEmpty()
                .WithMessage("DataSolicitacao não pode ser nulo.");

            RuleFor(r => r.Descricao)
                .NotEmpty()
                .WithMessage("Descrição não pode ser nulo.");

            RuleFor(r => r.TotalVacinados)
                .NotEmpty()
                .WithMessage("Total Vacinados não pode ser nulo.");
        }
    }
}
