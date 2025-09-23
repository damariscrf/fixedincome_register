using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Models;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Interface
{
    public interface IFixedIncomeGetByIdRepository
    {
        Task<FixedIncomeGetByIdOuput> FixedIncomeGetByIdAsync(CancellationToken cancellationToken);
    }
}
