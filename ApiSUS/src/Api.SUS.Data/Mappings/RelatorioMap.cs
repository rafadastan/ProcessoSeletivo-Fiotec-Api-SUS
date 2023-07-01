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
    public class RelatorioMap : IEntityTypeConfiguration<Relatorio>
    {
        public void Configure(EntityTypeBuilder<Relatorio> builder)
        {
            builder.ToTable("Relatorio");

            builder.HasKey(u => u.RelatorioId);
            
            builder.Property(u => u.RelatorioId)
                .HasColumnName("RelatorioId")
                .IsRequired();

            builder.Property(u => u.SolicitanteId)
                .HasColumnName("SolicitanteId")
                .IsRequired();

            builder.Property(u => u.DataSolicitacao)
                .HasColumnName("DataSolicitacao");

            builder.Property(u => u.DataAplicacao)
                .HasColumnName("DataAplicacao");

            builder.Property(u => u.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(100);

            builder.Property(u => u.TotalVacinados)
                .HasColumnName("TotalVacinados");

            builder.HasOne(s => s.Solicitante)
                .WithMany()
                .HasForeignKey(c => c.SolicitanteId);
        }
    }
}
