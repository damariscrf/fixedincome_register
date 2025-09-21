using MediatR;
using System.Collections.Generic;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Models
{
    public sealed class FixedIncomeGetAllInput : IRequest<IEnumerable<FixedIncomeGetAllOuput>>
    {
    }
}
