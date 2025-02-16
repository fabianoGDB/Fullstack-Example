using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Api.Common.Api;

namespace Dima.Api.Endpoints.Categories
{
    public static class Endpoint
    {
        //Extension Method
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("v1");

            endpoints.MapGroup("/categories")
            .WithTags("Categories")
            .MapEndpoint<CreateCategoryEndpoint>()
            .MapEndpoint<UpdateCategoryEndpoint>()
            .MapEndpoint<DeleteCategoryEndpoint>()
            .MapEndpoint<GetCategoryByIdEndpoint>()
            .MapEndpoint<GetAllCategoriesEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}