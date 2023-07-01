using Api.SUS.Domain.Contracts.ReadRepo;
using Api.SUS.Domain.Entities;
using Api.SUS.Domain.Model.QueryModel;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;

namespace Api.SUS.Data.ReadRepositories
{
    public class RelatorioReadRepository : BaseReadRepository<Relatorio, Guid>, 
        IRelatorioReadRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _susConnectionString;

        public RelatorioReadRepository(
            IConfiguration configuration)
        {
            _configuration = configuration;
            _susConnectionString = _configuration["ConnectionStrings:ApiSus"];
        }

        public async Task<Relatorio> GetByIdAsync(Guid id)
        {
            await using var connection = new SqlConnection(_susConnectionString);
            var query = await connection.QueryAsync<Relatorio>(@"
                SELECT * FROM Relatorio r
                WHERE r.Id = @Id",
                new
                {
                    Id = id
                });

            return query.FirstOrDefault()!;
        }

        public async Task<IEnumerable<RelatorioBySolicitanteDto>> GetAllBySolicitanteAsync(Guid solicitanteId)
        {
            await using var connection = new SqlConnection(_susConnectionString);
            var query = await connection.QueryAsync<RelatorioBySolicitanteDto>(@"
                SELECT r.*, s.Nome FROM Relatorio r
                    INNER JOIN Solicitante s ON s.SolicitanteId = r.SolicitanteId
                WHERE r.SolicitanteId = @SolicitanteId",
                new
                {
                    SolicitanteId = solicitanteId
                });


            return query.ToList();
        }
    }
}
