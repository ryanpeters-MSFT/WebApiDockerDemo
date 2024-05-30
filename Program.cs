var builder = WebApplication.CreateBuilder(args);

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

var clients = new[]
{
    new Client
    {
        Id = 1,
        Name = "Ryan",
        Title = "CSA"
    },
    new Client
    {
        Id = 2,
        Name = "Dan",
        Title = "Specialist"
    }
};

app.MapGet("/", () =>
{
    var welcomeMessage = configuration["WELCOME_MSG"];

    return Results.Ok(welcomeMessage);
});

app.MapGet("/clients", () =>
{
    return Results.Ok(clients);
});

app.MapGet("/clients/{id}", (int id) =>
{
    var client = clients.FirstOrDefault(c => c.Id == id);

    return Results.Ok(client);
});

app.Run();