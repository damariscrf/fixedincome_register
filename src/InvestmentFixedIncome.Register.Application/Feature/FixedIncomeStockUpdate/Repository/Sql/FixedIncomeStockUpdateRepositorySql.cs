namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Repository.Sql
{
    public static class FixedIncomeStockUpdateRepositorySql
    {
        internal const string _queryUpdate = @"UPDATE ""TB_RENDA_FIXA"" SET ""LASTRO"" = @stock WHERE ""RENDA_FIXA_ID"" = @fixedIncomeId";
    }
}
