using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Hendlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions
{
    public class GetTransactionsByPeriodEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/", HandleAsync)
                .WithName("Transactions: Get transactions by period")
                .WithSummary("Get a list of Transactions")
                .WithDescription("This method get a list of Transactions")
                .WithOrder(5)
                .Produces<PagedResponse<List<Transaction?>>>();

        public static async Task<IResult> HandleAsync(ITransactionHandler handler, [FromQuery] int pageNumber = Configuration.PageNumber, [FromQuery] int pageSize = Configuration.PageSize)
        {
            var request = new GetTransactionsByPeriodRequest
            {
                UserId = "hello@world.com",
                PageSize = pageSize,
                PageNumber = pageNumber
            };
            var result = await handler.GetByPeriodAsync(request);

            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Data);
        }
    }
}