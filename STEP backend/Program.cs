using STEP_backend.Architecture.Services;
using STEP_backend.Services;


var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

configuration.AddJsonFile("secrets.json", optional: true);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IAICommunicationService, AICommunicationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
