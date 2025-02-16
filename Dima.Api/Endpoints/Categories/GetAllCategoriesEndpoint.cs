using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Hendlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories
{
    public class GetAllCategoriesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/", HandleAsync)
                .WithName("Categories: Get all")
                .WithSummary("Get a list of Categories")
                .WithDescription("This method get a list of Categories")
                .WithOrder(5)
                .Produces<PagedResponse<List<Category?>>>();

        public static async Task<IResult> HandleAsync(ICategoryHandler handler, [FromQuery] int pageNumber = Configuration.PageNumber, [FromQuery] int pageSize = Configuration.PageSize)
        {
            var request = new GetAllCategoriesRequest
            {
                UserId = "hello@world.com",
                PageSize = pageSize,
                PageNumber = pageNumber
            };
            var result = await handler.GetAllAsync(request);

            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Data);
        }
    }
}