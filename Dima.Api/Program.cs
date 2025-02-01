var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Request - Requisição
//Get, Put, Post, Delete
app.MapGet("/", () => "Hello World!");
app.MapPost("/", () => "Hello World!");
app.MapPut("/", () => "Hello World!");
app.MapDelete("/", () => "Hello World!");

app.Run();
