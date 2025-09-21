using System.Data;

namespace InvestmentFixedIncome.Register.Application.Shared.Factories.Interface
{
    public interface IDbConnectionPostgree
    {
        IDbConnection GetConnectionStringPostgree();
    }
}
