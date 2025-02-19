using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Core.Hendlers
{
    public interface ITransactionHandler
    {

        Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
        Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
        Task<Response<Transaction?>> DaleteAsync(DeleteTransactionRequest request);
        Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request);
        Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionsByPeriodRequest request);
        Task<PagedResponse<List<Transaction>>> GetAllAsync(GetAllTransactionsRequest request);
    }
}