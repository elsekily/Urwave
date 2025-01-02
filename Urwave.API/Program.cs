using Urwave.Application;
using Urwave.DataAccess;
using Urwave.DataAccess.Persistence;
using FastEndpoints;
using Urwave.API.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDataAccess(builder.Configuration).AddApplication();
builder.Services.AddFastEndpoints();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseSerilogRequestLogging();


await AutomatedMigration.MigrateAsync(app.Services);

app.Run();