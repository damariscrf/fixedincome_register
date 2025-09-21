using InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Interface;
using InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.UseCase;
public class GetAllFixedIncomeUseCase(IGetAllFixedIncomeRepository repository) : IRequestHandler<GetAllFixedIncomeInput,IEnumerable<GetAllFixedIncomeOuput>>
{
    public async Task<IEnumerable<GetAllFixedIncomeOuput>> Handle(GetAllFixedIncomeInput request, CancellationToken cancellationToken) =>
        await repository.GetAllFixedIncomeAsync(cancellationToken);
}
