using Dima.Api.Data;
using Dima.Core.Models;
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


builder.Services.AddTransient<Handler>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

//Request - Requisição
//Get, Put, Post, Delete

app.MapPost(
    "/v1/trasactions",
    (Request request, Handler handler) => handler.Handle(request))
    .WithName("Transactions/Create")
    .WithSummary("Create a new trasnaction")
    .Produces<Response>();


app.Run();

// Request
public class Request
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
};

// Reponse

public class Response
{

    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
}

// Handler

public class Handler(AppDbContext context)
{

    public Response Handle(Request request)
    {
        var category = new Category
        {
            Title = request.Title,
            Description = request.Description,
        };
        context.Categories.Add(category);
        context.SaveChanges();
        return new Response { Id = category.Id, Title = category.Title };
    }
}