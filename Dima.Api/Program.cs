using Azure;
using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Hendlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
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

app.MapPost(
    "/v1/categories",
    (CreateCategoryRequest request, ICategoryHandler handler) => handler.CreateAsync(request))
    .WithName("Categories - Create")

    .WithSummary("Create a new category")
    .Produces<Response<Category>>();


app.MapPut(
    "/v1/categories",
    (UpdateCategoryRequest request, ICategoryHandler handler) => handler.UpdateAsync(request))
    .WithName("Categories - update")

    .WithSummary("update a new category")
    .Produces<Response<Category>>();

app.Run();

