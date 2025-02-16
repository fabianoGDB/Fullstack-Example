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
    public class DeleteCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapDelete("/{id}", HandleAsync)
                .WithName("Categories: Delete")
                .WithSummary("Dalete a Category")
                .WithDescription("This method delete a Category")
                .WithOrder(3)
                .Produces<Response<Category?>>();

        public static async Task<IResult> HandleAsync(ICategoryHandler handler, long id)
        {
            var request = new DeleteCategoryRequest
            {
                UserId = "hello@world.com",
                Id = id
            };

            var result = await handler.DaleteAsync(request);

            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Data);
        }
    }
}