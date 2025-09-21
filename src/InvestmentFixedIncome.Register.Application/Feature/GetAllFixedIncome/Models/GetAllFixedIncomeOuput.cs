namespace InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Models
{
    public class GetAllFixedIncomeOuput
    {
        public int FixedIncomeId { get; set; }
        public string BondAsset { get; set; }
        public string Index { get; set; }
        public decimal Tax { get; set; }
        public string IssuerName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
    }
}
