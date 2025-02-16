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
    public class UpdateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut(
                "/{id}", HandleAsync)
                .WithName("Categories: Update")
                .WithSummary("Update a Category")
                .WithDescription("This method update a Category")
                .WithOrder(2)
                .Produces<Response<Category?>>();

        public static async Task<IResult> HandleAsync(ICategoryHandler handler, UpdateCategoryRequest request, long id)
        {
            request.UserId = "hello@world.com";
            request.Id = id;
            var result = await handler.UpdateAsync(request);

            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Data);
        }
    }
}