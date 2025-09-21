using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Interface;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.UseCase
{
    public class FixedIncomeTaxUpdateUseCase : IRequestHandler<FixedIncomeTaxUpdateInput, bool>
    {
        private readonly IFixedIncomeTaxUpdateRepository _repository;
        private readonly ILogger<FixedIncomeTaxUpdateUseCase> _logger;
        public FixedIncomeTaxUpdateUseCase(
            IFixedIncomeTaxUpdateRepository repository,
            ILogger<FixedIncomeTaxUpdateUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<bool> Handle(FixedIncomeTaxUpdateInput request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.FixedIncomeTaxUpdateAsync(request, cancellationToken);
                if (!result)
                {
                    _logger.LogError("[FixedIncomeTaxUpdateUseCase][Handle] Error on update database => FixedIncomeId {FixedIncomeId}", request.FixedIncomeId);
                }
                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[FixedIncomeTaxUpdateUseCase][Handle] => Error on update database => FixedIncomeId {FixedIncomeId}", request.FixedIncomeId);
                return false;
            }

        }
    }
}