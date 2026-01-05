using JDAnalyser.API.Auth;
using JDAnalyser.Application.Services.Persistence;
using JDAnalyser.Infrastructure.Core;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// mapster
builder.Services.AddMapster(); 
var config = new TypeAdapterConfig();
config.Scan(typeof(Program).Assembly);
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

builder.Services.AddCoreInfrastructure(builder.Configuration);

builder.Services.AddScoped<JDAnalysisService>();

//Authentication
builder.Services.AddAuthentication("Session")
    .AddScheme<AuthenticationSchemeOptions, SessionAuthenticationHandler>("Session", null);

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
