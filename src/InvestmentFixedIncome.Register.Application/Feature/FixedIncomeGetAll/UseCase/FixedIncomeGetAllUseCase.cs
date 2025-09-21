using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Interface;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.UseCase;
public class FixedIncomeGetAllUseCase(IFixedIncomeGetAllRepository repository) : IRequestHandler<FixedIncomeGetAllInput,IEnumerable<FixedIncomeGetAllOuput>>
{
    public async Task<IEnumerable<FixedIncomeGetAllOuput>> Handle(FixedIncomeGetAllInput request, CancellationToken cancellationToken) =>
        await repository.FixedIncomeGetAllAsync(cancellationToken);
}
