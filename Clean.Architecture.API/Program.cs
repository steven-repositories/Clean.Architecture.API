using Microsoft.EntityFrameworkCore;
using Clean.Architecture.API.Application.Abstractions;
using Clean.Architecture.API.Application.Abstractions.Queries;
using Clean.Architecture.API.Application.Abstractions.Repositories;
using Clean.Architecture.API.Application.Services;
using Clean.Architecture.API.Application.Utilities;
using Clean.Architecture.API.Infrastructure.Data;
using Clean.Architecture.API.Infrastructure.Data.Queries;
using Clean.Architecture.API.Infrastructure.Data.Repositories;
using Clean.Architecture.API.Infrastructure.Middlewares;
using Clean.Architecture.API.Domain.Factories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>((options) =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CC")));

// Repositories
builder.Services.AddScoped<IApiSessionRepository, ApiSessionRepository>();
builder.Services.AddScoped<IAuthenticationSessionRepository, AuthenticationSessionRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();

// Query Services
builder.Services.AddScoped<IApiSessionQueryService, ApiSessionQueryService>();
builder.Services.AddScoped<IAuthenticationSessionQueryService, AuthenticationSessionQueryService>();
builder.Services.AddScoped<IPersonQueryService, PersonQueryService>();
builder.Services.AddScoped<IFileQueryService, FileQueryService>();
builder.Services.AddScoped<IClientQueryService, ClientQueryService>();

// Application Services
builder.Services.AddScoped<IApiSession, ApiSessionService>();
builder.Services.AddScoped<IAuthentication, AuthenticationService>();
builder.Services.AddScoped<IFileUpload, FileUploadService>();
builder.Services.AddScoped<IReport, ReportService>();
builder.Services.AddScoped<IPerson, PersonService>();

// Domain Factories
builder.Services.AddScoped<ApiSessionBuilderFactory>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ExecuteMigrations();

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
