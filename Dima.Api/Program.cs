var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Request - Requisição
//Get, Put, Post, Delete




app.MapGet("/get", (Request req) => "Hello World!");
app.MapPost("/post", () => "Hello World!");
app.MapPut("/put", () => "Hello World!");
app.MapDelete("/delete", () => "Hello World!");

app.Run();

// Request
public record Request();

// Reponse

// Handler
