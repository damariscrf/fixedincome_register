using MediatR;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Models
{
    public class FixedIncomeStockUpdateInput : IRequest<bool>
    {
        public int FixedIncomeId { get; private set; }
        public decimal Stock { get; set; }

        public bool Isvalid =>
            FixedIncomeId > 0;

        public void SetFixedIncomeId(int fixedIncomeId)
            => FixedIncomeId = fixedIncomeId;
    }
}
