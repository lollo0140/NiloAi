using NiloAI.src;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:8080");

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseDefaultFiles();
app.UseStaticFiles();

var nilo = new NiloChat(
    Path.Join(
        AppContext.BaseDirectory,
        "model",
        "gemma.gguf"
    )
);

app.MapPost("/chat", async (string userData) =>
{
    System.Console.WriteLine("prompt: " + userData);
    string risposta = await nilo.GetAIAnswer(userData);
    return Results.Ok(risposta.Replace("\n", "<br>"));
});

app.MapFallbackToFile("index.html");

app.Run();