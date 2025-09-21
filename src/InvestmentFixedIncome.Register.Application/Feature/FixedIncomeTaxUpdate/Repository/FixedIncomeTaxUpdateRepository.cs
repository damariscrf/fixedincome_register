using Dapper;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Interface;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Models;
using InvestmentFixedIncome.Register.Application.Shared.Configuration;
using InvestmentFixedIncome.Register.Application.Shared.Factories.Interface;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using static InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Repository.Sql.FixedIncomeTaxUpdateRepositorySql;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Repository
{
    public class FixedIncomeTaxUpdateRepository(IDbConnectionPostgree connection,
        IOptions<TimeoutOptions> options) : IFixedIncomeTaxUpdateRepository
    {
        public async Task<bool> FixedIncomeTaxUpdateAsync(FixedIncomeTaxUpdateInput request, CancellationToken cancellationToken)
        {
            using var conn = connection.GetConnectionStringPostgree();
            return await conn.ExecuteAsync(new CommandDefinition(
                parameters: new
                {
                    fixedIncomeId = request.FixedIncomeId,
                    tax = request.Tax
                },
                cancellationToken: cancellationToken,
                commandText: _queryUpdate,
                commandTimeout: options.Value.TimeoutDefault10seconds
           ))>0;
        }
    }
}
