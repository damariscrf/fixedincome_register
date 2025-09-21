using Dapper;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Interface;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Models;
using InvestmentFixedIncome.Register.Application.Shared.Configuration;
using InvestmentFixedIncome.Register.Application.Shared.Factories.Interface;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Repository.Sql.FixedIncomeGetAllRepositorySql;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Repository
{
    public class FixedIncomeGetAllRepository(IDbConnectionPostgree connection,
        IOptions<TimeoutOptions> options) : IFixedIncomeGetAllRepository
    {
        public async Task<IEnumerable<FixedIncomeGetAllOuput>> FixedIncomeGetAllAsync(CancellationToken cancellationToken)
        {
            using var conn = connection.GetConnectionStringPostgree();
            return await conn.QueryAsync<FixedIncomeGetAllOuput>(new CommandDefinition(
               cancellationToken: cancellationToken,
               commandText: _query,
               commandTimeout: options.Value.TimeoutDefault10seconds
           ));
        }
    }
}
