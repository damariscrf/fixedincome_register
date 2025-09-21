namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Repository.Sql
{
    public static class FixedIncomeTaxUpdateRepositorySql
    {
        internal const string _queryUpdate = @"UPDATE ""TB_RENDA_FIXA"" SET ""TAXA"" = @tax WHERE ""RENDA_FIXA_ID"" = @fixedIncomeId";
    }
}
