var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () =>
{
    return $"λ - dotnet 6 minimal api sample";
});

app.MapGet("/ping/{name}", async (string name) =>
{
    return $"pong {name}";
});

app.Run();