using MediatR;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Models
{
    public sealed class FixedIncomeGetByIdInput : IRequest<FixedIncomeGetByIdOuput>
    {
        public int FixedIncomeId { get; set; }
        public FixedIncomeGetByIdInput(int fixedIncomeId)
        {
            FixedIncomeId = fixedIncomeId;
        }
    }
}
