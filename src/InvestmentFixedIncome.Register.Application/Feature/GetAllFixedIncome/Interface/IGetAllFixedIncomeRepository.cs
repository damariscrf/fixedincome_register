using InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Interface
{
    public interface IGetAllFixedIncomeRepository
    {
        Task<IEnumerable<GetAllFixedIncomeOuput>> GetAllFixedIncomeAsync(CancellationToken cancellationToken);
    }
}
