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
    public class CreateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPost(
                "/", HandleAsync)
                .WithName("Categories: Create")
                .WithSummary("Create a new Category")
                .WithDescription("This method crate a new Category")
                .WithOrder(1)
                .Produces<Response<Category?>>();

        public static async Task<IResult> HandleAsync(ICategoryHandler handler, CreateCategoryRequest request)
        {
            request.UserId = "hello@world.com";
            var result = await handler.CreateAsync(request);

            return result.IsSuccess ? Results.Created($"/{result.Data?.Id}", result) : Results.BadRequest(result);
        }

    }
}