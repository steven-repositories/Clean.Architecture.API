using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions.Controllers;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Application.Services;
using TAN_10042024.Infrastructure.Data;
using TAN_10042024.Infrastructure.Data.Queries;
using TAN_10042024.Infrastructure.Data.Repositories;
using TAN_10042024.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>((options) =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CC")));

// Repositories
builder.Services.AddScoped<ApiSessionsRepository>();
builder.Services.AddScoped<AuthenticationSessionsRepository>();
builder.Services.AddScoped<PersonsRepository>();
builder.Services.AddScoped<FilesRepository>();

// Query Services
builder.Services.AddScoped<IApiSessionsQueryService, ApiSessionsQueryService>();
builder.Services.AddScoped<IAuthenticationSessionsQueryService, AuthenticationSessionsQueryService>();
builder.Services.AddScoped<IPersonsQueryService, PersonsQueryService>();
builder.Services.AddScoped<IFilesQueryService, FilesQueryService>();
builder.Services.AddScoped<IClientsQueryService, ClientsQueryService>();

// Application Services
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IPersonService, PersonService>();

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
