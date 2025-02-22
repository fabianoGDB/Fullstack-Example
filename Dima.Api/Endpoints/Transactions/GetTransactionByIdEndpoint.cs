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
    public class GetTransactionByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/{id}", HandleAsync)
                .WithName("Transactions: Get by id")
                .WithSummary("Get a transaction")
                .WithDescription("This method get a transaction by her id")
                .WithOrder(4)
                .Produces<Response<Transaction?>>();

        public static async Task<IResult> HandleAsync(ITransactionHandler handler, long id)
        {
            var request = new GetTransactionByIdRequest
            {
                UserId = "hello@world.com",
                Id = id
            };
            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Data);
        }
    }
}