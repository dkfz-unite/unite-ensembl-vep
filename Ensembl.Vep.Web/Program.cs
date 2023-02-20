var builder = WebApplication.CreateBuilder(args);

// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline

app.UseAuthorization();

app.MapControllers();

app.Run();

