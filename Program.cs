using NiloAI.src;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var nilo = new NiloChat(Path.Join(AppContext.BaseDirectory, "model", "gemma.gguf"));

app.MapPost("/chat", async (string userData) =>
{
    string risposta = await nilo.GetAIAnswer(userData);

    return Results.Ok(risposta);
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
