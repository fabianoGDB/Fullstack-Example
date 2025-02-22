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
    public class CreateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPost(
                "/", HandleAsync)
                .WithName("Transactions: Create")
                .WithSummary("Create a new Transaction")
                .WithDescription("This method crate a new Transaction")
                .WithOrder(1)
                .Produces<Response<Transaction?>>();

        public static async Task<IResult> HandleAsync(ITransactionHandler handler, CreateTransactionRequest request)
        {
            request.UserId = "hello@world.com";
            var result = await handler.CreateAsync(request);

            return result.IsSuccess ? Results.Created($"/{result.Data?.Id}", result) : Results.BadRequest(result);
        }

    }
}