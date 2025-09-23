using Dapper;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Interface;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Models;
using InvestmentFixedIncome.Register.Application.Shared.Configuration;
using InvestmentFixedIncome.Register.Application.Shared.Factories.Interface;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Repository.Sql.FixedIncomeGetByIdRepositorySql;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Repository
{
    public class FixedIncomeGetByIdRepository(IDbConnectionPostgree connection,
        IOptions<TimeoutOptions> options) : IFixedIncomeGetByIdRepository
    {
        public async Task<FixedIncomeGetByIdOuput> FixedIncomeGetByIdAsync(CancellationToken cancellationToken)
        {
            using var conn = connection.GetConnectionStringPostgree();
            return await conn.QueryFirstOrDefaultAsync<FixedIncomeGetByIdOuput>(new CommandDefinition(
               cancellationToken: cancellationToken,
               commandText: _query,
               commandTimeout: options.Value.TimeoutDefault10seconds
           ));
        }
    }
}
