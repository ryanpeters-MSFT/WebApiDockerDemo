var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

var configuration = app.Services.GetService<IConfiguration>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () =>
{
    var welcomeMessage = configuration["WELCOME_MSG"];

    return Results.Ok(welcomeMessage);
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();