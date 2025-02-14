using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Hendlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    x =>
    {
        x.UseSqlServer(builder.Configuration.GetConnectionString("DockerConnection"));
    }
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});


builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

//Request - Requisição
//Get, Put, Post, Delete


app.MapGet(
    "/v1/categories/{id}",
    async (long id, ICategoryHandler handler) =>
    {
        var request = new GetCategoryByIdRequest { Id = id };
        return await handler.GetByIdAsync(request);
    })
    .WithName("Categories - Get by Id")

    .WithSummary("Category seach")
    .Produces<Response<Category>>();


app.MapGet(
    "/v1/categories",
    async ([FromBody] GetAllCategoriesRequest request, ICategoryHandler handler) => await handler.GetAllAsync(request))
    .WithName("Categories - Get All")

    .WithSummary("Categories seach")
    .Produces<PagedResponse<List<Category>>>();

app.MapPost(
    "/v1/categories",
    async ([FromBody] CreateCategoryRequest request, ICategoryHandler handler) => await handler.CreateAsync(request))
    .WithName("Categories - Create")

    .WithSummary("Create a new category")
    .Produces<Response<Category>>();


app.MapPut(
    "/v1/categories/{id}",
    async (long id, [FromBody] UpdateCategoryRequest request, ICategoryHandler handler) =>
    {
        request.Id = id;
        return await handler.UpdateAsync(request);
    })
    .WithName("Categories - update")

    .WithSummary("update a category")
    .Produces<Response<Category>>();


app.MapDelete(
    "/v1/categories/{id}",
    async (long id, ICategoryHandler handler) =>
    {
        var request = new DeleteCategoryRequest { Id = id };
        return await handler.DaleteAsync(request);
    })
    .WithName("Categories - delete")

    .WithSummary("delete a category")
    .Produces<Response<Category>>();


app.Run();

