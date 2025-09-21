using Dapper;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Interface;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Models;
using InvestmentFixedIncome.Register.Application.Shared.Configuration;
using InvestmentFixedIncome.Register.Application.Shared.Factories.Interface;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using static InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Repository.Sql.FixedIncomeStockUpdateRepositorySql;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Repository
{
    public class FixedIncomeStockUpdateRepository(IDbConnectionPostgree connection,
        IOptions<TimeoutOptions> options) : IFixedIncomeStockUpdateRepository
    {
        public async Task<bool> FixedIncomeStockUpdateAsync(FixedIncomeStockUpdateInput request, CancellationToken cancellationToken)
        {
            using var conn = connection.GetConnectionStringPostgree();
            return await conn.ExecuteAsync(new CommandDefinition(
                parameters: new
                {
                    fixedIncomeId = request.FixedIncomeId,
                    stock = request.Stock
                },
                cancellationToken: cancellationToken,
                commandText: _queryUpdate,
                commandTimeout: options.Value.TimeoutDefault10seconds
           ))>0;
        }
    }
}
