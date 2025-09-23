using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Interface;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.UseCase;
public class FixedIncomeGetByIdUseCase(IFixedIncomeGetByIdRepository repository) : IRequestHandler<FixedIncomeGetByIdInput,FixedIncomeGetByIdOuput>
{
    public async Task<FixedIncomeGetByIdOuput> Handle(FixedIncomeGetByIdInput request, CancellationToken cancellationToken) =>
        await repository.FixedIncomeGetByIdAsync(cancellationToken);
}
