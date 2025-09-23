namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Repository.Sql
{
    public static class FixedIncomeGetByIdRepositorySql
    {
        internal const string _query = @"SELECT ""RENDA_FIXA_ID"" AS FixedIncomeId,
                                               LENGTH(""NAME"") AS BondAsset,
                                               ""VALUE"" AS Value,
                                               ""TAXA"" AS Tax,
                                               ""LASTRO"" AS Stock,
                                               ""INDEXADOR"" AS Index,
                                               ""EMISSOR"" AS IssuerName
                                         FROM ""TB_RENDA_FIXA""
                                         ORDER BY ""TAXA"" ASC";
    }
}
