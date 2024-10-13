using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Application.Abstractions.Repositories;
using TAN_10042024.Application.Mappers;
using TAN_10042024.Application.Profiles;
using TAN_10042024.Application.Services;
using TAN_10042024.Infrastructure.Data;
using TAN_10042024.Infrastructure.Data.Queries;
using TAN_10042024.Infrastructure.Data.Repositories;
using TAN_10042024.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>((options) =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CC")));

// Profile Mappers
builder.Services.AddAutoMapper(typeof(ApiSessionProfile));
builder.Services.AddAutoMapper(typeof(AuthenticationSessionProfile));
builder.Services.AddAutoMapper(typeof(ClientProfile));
builder.Services.AddAutoMapper(typeof(FileProfile));
builder.Services.AddAutoMapper(typeof(PersonProfile));

// Repositories
builder.Services.AddScoped<IApiSessionsRepository, ApiSessionsRepository>();
builder.Services.AddScoped<IAuthenticationSessionsRepository, AuthenticationSessionsRepository>();
builder.Services.AddScoped<IPersonsRepository, PersonsRepository>();
builder.Services.AddScoped<IFilesRepository, FilesRepository>();

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

using var serviceScope = app
    .Services
    .CreateScope();

var dbContext = serviceScope
    .ServiceProvider
    .GetRequiredService<AppDbContext>()
    .Database;

dbContext.Migrate();

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
