using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Models;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Interface
{
    public interface IFixedIncomeStockUpdateRepository
    {
        Task<bool> FixedIncomeStockUpdateAsync(FixedIncomeStockUpdateInput request,CancellationToken cancellationToken);
    }
}
