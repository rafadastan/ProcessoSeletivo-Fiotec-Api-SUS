using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.SUS.Data.Mappings
{
    public class SolicitanteMap : IEntityTypeConfiguration<Solicitante>
    {
        public void Configure(EntityTypeBuilder<Solicitante> builder)
        {
            builder.ToTable("Solicitante");

            builder.HasKey(u => u.SolicitanteId);

            builder.Property(u => u.SolicitanteId)
                .HasColumnName("SolicitanteId")
                .IsRequired();

            builder.Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.CPF)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(u => u.DataConsulta)
                .HasColumnName("DataConsulta");
            
        }
    }
}
