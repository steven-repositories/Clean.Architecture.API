using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Data;
using TAN_10042024.Application.Services;
using TAN_10042024.Framework.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

builder.Services.AddDbContext<AppDbContext>((options) =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CC")));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
