using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Api.Common.Api;
using Dima.Core.Hendlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Transactions
{
    public class UpdateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut(
                "/{id}", HandleAsync)
                .WithName("Transactions: Update")
                .WithSummary("Update a Transaction")
                .WithDescription("This method update a Transaction")
                .WithOrder(2)
                .Produces<Response<Transaction?>>();

        public static async Task<IResult> HandleAsync(ITransactionHandler handler, UpdateTransactionRequest request, long id)
        {
            request.UserId = "hello@world.com";
            request.Id = id;
            var result = await handler.UpdateAsync(request);

            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Data);
        }
    }
}