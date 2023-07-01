using Api.SUS.Domain.Contracts.ReadRepo;
using Api.SUS.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Api.SUS.Data.ReadRepositories
{
    public class SolicitanteReadRepository : ISolicitanteReadRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _susConnectionString;

        public SolicitanteReadRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _susConnectionString = _configuration["ConnectionStrings:ApiSus"]; ;
        }

        public async Task<bool> GetByCpfExists(string cpf)
        {
            await using var connection = new SqlConnection(_susConnectionString);
            var query = await connection.QueryAsync(@"
                SELECT s.Cpf FROM Solicitante s
                WHERE s.Nome = @Nome 
                AND s.Cpf = @CPF", 
             new
            {
                 CPF = cpf
            });

            return query.Any();
        }

        public async Task<Solicitante> GetByCpfAndName(string cpf, string name)
        {
            await using var connection = new SqlConnection(_susConnectionString);
            var query = await connection.QueryAsync(@"
                SELECT * FROM Solicitante s
                WHERE s.Nome = @Nome 
                AND s.Cpf = @CPF",
                new
                {
                    CPF = cpf,
                    Name = name
                });

            return query.FirstOrDefault()!;
        }
    }
}
