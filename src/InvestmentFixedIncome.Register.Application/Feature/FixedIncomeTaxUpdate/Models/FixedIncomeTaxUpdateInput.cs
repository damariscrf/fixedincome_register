using MediatR;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Models
{
    public class FixedIncomeTaxUpdateInput : IRequest<bool>
    {
        public int FixedIncomeId { get; private set; }
        public decimal Tax { get; set; }

        public bool Isvalid =>
            FixedIncomeId > 0;

        public void SetFixedIncomeId(int fixedIncomeId)
            => FixedIncomeId = fixedIncomeId;
    }
}
