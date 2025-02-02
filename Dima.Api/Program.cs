var builder = WebApplication.CreateBuilder(args);


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
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int Type { get; set; }
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string UserId { get; set; } = string.Empty;
};

// Reponse

public class Response
{

    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
}

// Handler

public class Handler
{

    public Response Handle(Request request)
    {
        return new Response { Id = 1, Title = request.Title };
    }
}