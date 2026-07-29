using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using ModelBinding.options;
using ModelBinding.Repository;
using ModelBinding.Repository.Services;
using Serilog;
//using RedisCachingDemo.Data;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPService, PService>();
builder.Services.AddScoped<IBookingDetailService, BookingDetailService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.Configure<textFileLoggerOptions>(
    builder.Configuration.GetSection("TextFileLogger"));
builder.Services.AddMemoryCache();
builder.Services.AddScoped<LocationRespository>();
builder.Services.AddScoped<AddressService>();

builder.Services.AddSingleton<
    ICorrelationIdAccessor,
    CorrelationIdAccessor>();

builder.Logging.ClearProviders();

builder.Services.AddSingleton<ILoggerProvider,
    textFileLoggerProvider>();


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt")
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddStackExchangeRedisCache(options =>
{
   
    options.Configuration = builder.Configuration["RedisCacheOptions:Configuration"];
    options.InstanceName = builder.Configuration["RedisCacheOptions:InstanceName"];
});
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect(builder.Configuration["RedisCacheOptions:Configuration"]));

//builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();



builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT Token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
Log.Information("Application Started");
app.Run();

