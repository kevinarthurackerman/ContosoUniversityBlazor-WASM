﻿using System;
using System.Threading;
using System.Threading.Tasks;
using ContosoUniversity.Server.Data;
using MediatR;

namespace ContosoUniversity.Server.Infrastructure
{
    public class TransactionBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly SchoolContext _dbContext;

        public TransactionBehavior(SchoolContext dbContext) => _dbContext = dbContext;

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                await _dbContext.BeginTransactionAsync();
                var response = await next();
                await _dbContext.CommitTransactionAsync();
                return response;
            }
            catch (Exception)
            {
                _dbContext.RollbackTransaction();
                throw;
            }
        }
    }
}
