using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Interface
{
    public interface IFixedIncomeGetAllRepository
    {
        Task<IEnumerable<FixedIncomeGetAllOuput>> FixedIncomeGetAllAsync(CancellationToken cancellationToken);
    }
}
