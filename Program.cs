using QuizApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Leaderboard memory mein store hota hai (app restart pe reset ho jata hai)
builder.Services.AddSingleton<LeaderboardStore>();

// React app (Vite) port 5173 pe chalti hai, usko API call karne ki permission
builder.Services.AddCors(options =>
{
    options.AddPolicy("react", policy => policy
        .WithOrigins("http://localhost:5173", "http://127.0.0.1:5173")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("react");
app.MapControllers();
app.MapGet("/", () => Results.Redirect("/api/quiz/categories"));

app.Run();
