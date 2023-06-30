using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Domain.Entities;

namespace Api.SUS.Domain.FluentValidations
{
    public class SolicitanteValidation : AbstractValidator<Solicitante>
    {
        public SolicitanteValidation()
        {
            RuleFor(r => r.SolicitanteId)
                .NotEmpty()
                .WithMessage("O Id não pode ser nulo.");

            RuleFor(r => r.Nome)
                .NotEmpty()
                .WithMessage("O Nome não pode ser nulo.");

            RuleFor(r => r.CPF)
                .NotEmpty()
                .WithMessage("O CPF não pode ser nulo.");

            RuleFor(r => r.DataConsulta)
                .NotEmpty()
                .WithMessage("Data Consulta não pode ser nulo.");
        }
    }
}
