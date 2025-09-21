using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Interface;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.UseCase
{
    public class FixedIncomeStockUpdateUseCase : IRequestHandler<FixedIncomeStockUpdateInput, bool>
    {
        private readonly IFixedIncomeStockUpdateRepository _repository;
        private readonly ILogger<FixedIncomeStockUpdateUseCase> _logger;
        public FixedIncomeStockUpdateUseCase(
            IFixedIncomeStockUpdateRepository repository,
            ILogger<FixedIncomeStockUpdateUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<bool> Handle(FixedIncomeStockUpdateInput request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.FixedIncomeStockUpdateAsync(request, cancellationToken);
                if (!result)
                {
                    _logger.LogError("[FixedIncomeStockUpdateUseCase][Handle] Error on update database => FixedIncomeId {FixedIncomeId}", request.FixedIncomeId);
                }
                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[FixedIncomeStockUpdateUseCase][Handle] => Error on update database => FixedIncomeId {FixedIncomeId}", request.FixedIncomeId);
                return false;
            }

        }
    }
}