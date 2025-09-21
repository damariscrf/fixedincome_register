using MediatR;
using System.Collections.Generic;

namespace InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Models
{
    public sealed class GetAllFixedIncomeInput : IRequest<IEnumerable<GetAllFixedIncomeOuput>>
    {
    }
}
