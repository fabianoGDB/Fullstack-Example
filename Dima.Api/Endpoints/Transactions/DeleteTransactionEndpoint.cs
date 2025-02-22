using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Api.Common.Api;
using Dima.Core.Hendlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Transactions
{
    public class DeleteTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapDelete("/{id}", HandleAsync)
                .WithName("Transaction: Delete")
                .WithSummary("Dalete a Transaction")
                .WithDescription("This method delete a Transaction")
                .WithOrder(3)
                .Produces<Response<Transaction?>>();

        public static async Task<IResult> HandleAsync(ITransactionHandler handler, long id)
        {
            var request = new DeleteTransactionRequest
            {
                UserId = "hello@world.com",
                Id = id
            };

            var result = await handler.DaleteAsync(request);

            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Data);
        }
    }
}