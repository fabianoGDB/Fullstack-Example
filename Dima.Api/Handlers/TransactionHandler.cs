using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Api.Data;
using Dima.Core.Common.Extensions;
using Dima.Core.Hendlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers
{
    public class TransactionHandler(AppDbContext context) : ITransactionHandler
    {
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            try
            {

                var transaction = new Transaction
                {
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    CreatedAt = DateTime.UtcNow,
                    Amount = request.Amount,
                    PaidOrReceivedAt = request.PaidOrReceivedAt,
                    Title = request.Title,
                    Type = request.Type,
                };

                await context.Transactions.AddAsync(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 201, "Created");
            }
            catch
            {

                return new Response<Transaction?>(null, 500, "Não foi possivel");
            }
        }

        public async Task<Response<Transaction?>> DaleteAsync(DeleteTransactionRequest request)
        {
            try
            {
                var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transaction == null)
                {
                    return new Response<Transaction?>(null, 404, "Trasação não encontrada");
                }

                context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 200, "deleted");
            }
            catch
            {

                return new Response<Transaction?>(null, 500, "Não foi possivel");
            }
        }

        public async Task<PagedResponse<List<Transaction>>> GetAllAsync(GetAllTransactionsRequest request)
        {
            try
            {
                var transactions = await context.Transactions.Where(x => x.UserId == request.UserId).ToListAsync();

                if (transactions == null)
                {
                    return new PagedResponse<List<Transaction>>(null, 404, "Trasação não encontrada");
                }

                return new PagedResponse<List<Transaction>>(transactions, 200, "Succces");
            }
            catch
            {

                return new PagedResponse<List<Transaction>>(null, 500, "Não foi possivel encontra");
            }
        }

        public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
        {
            try
            {
                var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transaction == null)
                {
                    return new Response<Transaction?>(null, 404, "Trasação não encontrada");
                }

                return new Response<Transaction?>(transaction, 200);
            }
            catch
            {

                return new Response<Transaction?>(null, 500, "Não foi possivel encontra");
            }
        }

        public async Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
        {
            try
            {

                request.StartDate ??= DateTime.Now.GetFirstDay();
                request.EndDate ??= DateTime.Now.GetLastDay();
            }
            catch
            {
                return new PagedResponse<List<Transaction>>(null, 500, "erro ao tentar converter a data passada");
            }


            try
            {
                var query = context.Transactions
                .AsNoTracking()
                .Where(x => x.CreatedAt >= request.StartDate && x.CreatedAt <= request.EndDate && x.UserId == request.UserId)
                .OrderBy(x => x.CreatedAt);

                var transactions = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query
                .CountAsync();

                return new PagedResponse<List<Transaction>>(transactions, count, request.PageNumber, request.PageSize);
            }
            catch
            {

                return new PagedResponse<List<Transaction>>(null, 500, "Não foi possivel obter as transações");
            }
        }

        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
        {
            try
            {
                var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transaction == null)
                {
                    return new Response<Transaction?>(null, 404, "Trasação não encontrada");
                }

                transaction.CategoryId = request.CategoryId;
                transaction.Amount = request.Amount;
                transaction.Title = request.Title;
                transaction.Type = request.Type;
                transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;

                context.Transactions.Update(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 200, "Updadated");
            }
            catch
            {

                return new Response<Transaction?>(null, 500, "Não foi possivel");
            }
        }
    }
}