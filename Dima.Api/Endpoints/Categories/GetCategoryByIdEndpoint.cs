using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Api.Common.Api;
using Dima.Core.Hendlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Categories
{
    public class GetCategoryByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/{id}", HandleAsync)
                .WithName("Categories: Get by id")
                .WithSummary("Get a Category")
                .WithDescription("This method get a Category by her id")
                .WithOrder(4)
                .Produces<Response<Category?>>();

        public static async Task<IResult> HandleAsync(ICategoryHandler handler, long id)
        {
            var request = new GetCategoryByIdRequest
            {
                UserId = "hello@world.com",
                Id = id
            };
            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Data);
        }
    }
}