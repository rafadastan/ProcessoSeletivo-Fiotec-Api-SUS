using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Domain.Entities;

namespace Api.SUS.Data.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<Solicitante> Solicitante { get; set; }
        public DbSet<Relatorio> Relatorio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solicitante>()
                .HasIndex(c => c.Id);

            modelBuilder.Entity<Relatorio>()
                .HasIndex(c => c.Id);

            modelBuilder.Entity<Solicitante>(entity => {
                entity.HasIndex(c => c.CPF).IsUnique();
            });

        }
    }
}
