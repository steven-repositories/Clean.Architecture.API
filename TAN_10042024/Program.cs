using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Data;
using TAN_10042024.Application.Services;
using TAN_10042024.Domain.Entities;
using TAN_10042024.Framework.Middlewares;
using TAN_10042024.Framework.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>((options) =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CC")));

builder.Services.AddScoped<ApiSessionsRepository>();
builder.Services.AddScoped<AuthenticationSessionsRepository>();
builder.Services.AddScoped<IAuthentication, AuthenticationService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware(s)
app.UseMiddleware<RequestLoggerMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
