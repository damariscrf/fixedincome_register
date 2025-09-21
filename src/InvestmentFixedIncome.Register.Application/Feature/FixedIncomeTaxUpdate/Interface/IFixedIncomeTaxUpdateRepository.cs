using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Models;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Interface
{
    public interface IFixedIncomeTaxUpdateRepository
    {
        Task<bool> FixedIncomeTaxUpdateAsync(FixedIncomeTaxUpdateInput request,CancellationToken cancellationToken);
    }
}
