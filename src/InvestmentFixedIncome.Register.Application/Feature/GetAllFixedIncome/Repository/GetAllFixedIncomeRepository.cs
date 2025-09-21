using Dapper;
using InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Interface;
using InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Models;
using InvestmentFixedIncome.Register.Application.Shared.Configuration;
using InvestmentFixedIncome.Register.Application.Shared.Factories.Interface;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Repository.Sql.GetAllFixedIncomeRepositorySql;

namespace InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Repository
{
    public class GetAllFixedIncomeRepository(IDbConnectionPostgree connection,
        IOptions<TimeoutOptions> options) : IGetAllFixedIncomeRepository
    {
        public async Task<IEnumerable<GetAllFixedIncomeOuput>> GetAllFixedIncomeAsync(CancellationToken cancellationToken)
        {
            using var conn = connection.GetConnectionStringPostgree();
            return await conn.QueryAsync<GetAllFixedIncomeOuput>(new CommandDefinition(
               cancellationToken: cancellationToken,
               commandText: _query,
               commandTimeout: options.Value.TimeoutDefault10seconds
           ));
        }
    }
}
