﻿// <auto-generated />
using System;
using Api.SUS.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.SUS.Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20230701170834_RelacionamentoMapper")]
    partial class RelacionamentoMapper
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Api.SUS.Domain.Entities.Relatorio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSolicitacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RelatorioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SolicitanteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalVacinados")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("SolicitanteId");

                    b.ToTable("Relatorio");
                });

            modelBuilder.Entity("Api.SUS.Domain.Entities.Solicitante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SolicitanteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Id");

                    b.ToTable("Solicitante");
                });

            modelBuilder.Entity("Api.SUS.Domain.Entities.Relatorio", b =>
                {
                    b.HasOne("Api.SUS.Domain.Entities.Solicitante", "Solicitante")
                        .WithMany("RelatorioList")
                        .HasForeignKey("SolicitanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solicitante");
                });

            modelBuilder.Entity("Api.SUS.Domain.Entities.Solicitante", b =>
                {
                    b.Navigation("RelatorioList");
                });
#pragma warning restore 612, 618
        }
    }
}