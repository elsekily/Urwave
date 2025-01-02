using Urwave.Application;
using Urwave.DataAccess;
using Urwave.DataAccess.Persistence;
using FastEndpoints;
using Urwave.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDataAccess(builder.Configuration).AddApplication();
builder.Services.AddFastEndpoints();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


await AutomatedMigration.MigrateAsync(app.Services);

app.Run();