using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.Application.Shared.Middlewares
{
    public class ExceptionHandler<TRequest, TException> : IRequestExceptionAction<TRequest, TException> where TException : Exception
    {
        private readonly ILogger<ExceptionHandler<TRequest, TException>> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler<TRequest, TException>> logger)
        {
            _logger = logger;
        }
        public async Task Execute(TRequest request, TException exception, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _logger.LogError(exception, "[UseCase][Exceção] => type {@requestType} request: ({@request})", request.GetType().Name, request);
        }
    }
}
