using InvestmentFixedIncome.Register.Application.Shared.Configuration;
using InvestmentFixedIncome.Register.Application.Shared.Factories.Interface;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace InvestmentFixedIncome.Register.Application.Shared.Factories
{
    public class DbConnectionPostgree(IOptions<ConnectionStringsOptions> databaseoptions) : IDbConnectionPostgree
    {
        public IDbConnection GetConnectionStringPostgree() =>
            new  NpgsqlConnection(databaseoptions.Value.ConnectionStringRegister);
    }
}
